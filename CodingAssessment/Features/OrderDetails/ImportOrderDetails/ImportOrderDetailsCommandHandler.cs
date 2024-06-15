using System.Globalization;
using CodingAssessment.Database;
using CodingAssessment.Exceptions;
using CodingAssessment.Mapping;
using CodingAssessment.Utilities;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidationException = CodingAssessment.Exceptions.ValidationException;

namespace CodingAssessment.Features.OrderDetails.ImportOrderDetails;

/// <summary>
/// Contains the handler for processing the import command.
/// </summary>
public sealed class ImportOrderDetailsCommandHandler
{
    internal sealed class Handler : IRequestHandler<ImportOrderDetailsCommand, Unit>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ImportOrderDetailsCommand request, CancellationToken cancellationToken)
        {
            var fileValidation = await new ImportOrderDetailsFileValidation()
                .ValidateAsync(request.OrderDetailsRequest, cancellationToken);

            if (!fileValidation.IsValid)
            {
                var errorMessages = fileValidation.Errors
                    .Select(e => e.ErrorMessage);
                
                throw new ValidationException(errorMessages);
            }

            try
            {
                using var reader = new StreamReader(request.OrderDetailsRequest.File.OpenReadStream());
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                });

                var pizzaIds = await _context.Pizzas
                    .Select(x => x.Id)
                    .ToListAsync(cancellationToken);
                var pizzaIdsHashSet = new HashSet<string>(pizzaIds);

                csv.Context.RegisterClassMap(new OrderDetailsMap(pizzaIdsHashSet));

                var orderDetails = csv.GetRecordsAsync
                    <Models.OrderDetails>(cancellationToken);

                var batchSize = 1000;
                var batch = new List<Models.OrderDetails>();
                await foreach (var record in orderDetails)
                {
                    var dataValidation = await new ImportOrderDetailsDataValidation()
                        .ValidateAsync(record, cancellationToken);

                    if (!dataValidation.IsValid)
                    {
                        continue;
                    }
                    
                    batch.Add(record);

                    if (batch.Count >= batchSize)
                    {
                        await ProcessBatchAsync(batch, cancellationToken);
                        batch.Clear();
                    }
                }

                if (batch.Count > 0)
                {
                    await ProcessBatchAsync(batch, cancellationToken);
                }

                return Unit.Value;
            }
            catch (ReaderException ex)
            {
                throw new CsvProcessingException (ErrorMessages.CsvProcessingError, ex);
            }        
        }

        private async Task ProcessBatchAsync(List<Models.OrderDetails> batch, CancellationToken cancellationToken)
        {
            var orderIds = batch.Select(od => od.OrderId).Distinct().ToList();

            var existingOrderIds = await _context.Orders
                .Where(o => orderIds.Contains(o.Id))
                .Select(o => o.Id)
                .ToListAsync(cancellationToken);
            
            var validOrderDetails = batch.Where(od => existingOrderIds.Contains(od.OrderId)).ToList();

            foreach (var orderDetail in validOrderDetails)
            {
                _context.OrderDetails.Add(orderDetail);
            }
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
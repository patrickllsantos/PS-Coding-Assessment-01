using System.Globalization;
using CodingAssessment.Database;
using CodingAssessment.Exceptions;
using CodingAssessment.Mapping.CsvMapping;
using CodingAssessment.Models;
using CodingAssessment.Utilities;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using ValidationException = CodingAssessment.Exceptions.ValidationException;

namespace CodingAssessment.Features.Orders.ImportOrders;

/// <summary>
/// Contains the handler for processing the import command.
/// </summary>
public static class ImportOrdersCommandHandler
{
    internal sealed class Handler : IRequestHandler<ImportOrdersCommand, Unit>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(ImportOrdersCommand request, CancellationToken cancellationToken)
        {
            var fileValidation = await new ImportOrdersFileValidation()
                .ValidateAsync(request.OrdersRequest, cancellationToken);

            if (!fileValidation.IsValid)
            {
                var errorMessages = fileValidation.Errors
                    .Select(e => e.ErrorMessage);
                
                throw new ValidationException(errorMessages);
            }

            try
            {
                using var reader = new StreamReader(request.OrdersRequest.File.OpenReadStream());
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                });

                csv.Context.RegisterClassMap(new OrderMap());
                var orders = csv.GetRecords<Order>().ToList();

                _context.Orders.AddRange(orders);
                 await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new CsvProcessingException (ErrorMessages.CsvProcessingError, ex);
            }        
        }
    }
}
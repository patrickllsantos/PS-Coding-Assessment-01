using System.Globalization;
using CodingAssessment.Database;
using CodingAssessment.Exceptions;
using CodingAssessment.Features.Shared.Import;
using CodingAssessment.Mapping.CsvMapping;
using CodingAssessment.Models;
using CodingAssessment.Utilities;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidationException = CodingAssessment.Exceptions.ValidationException;

namespace CodingAssessment.Features.Orders.Import;

/// <summary>
/// Contains the handler for processing the import command.
/// </summary>
public static class ImportCommandHandler
{
    internal sealed class Handler : IRequestHandler<ImportCommand, Unit>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(ImportCommand request, CancellationToken cancellationToken)
        {
            var fileValidation = await new ImportFileValidation()
                .ValidateAsync(request.Request, cancellationToken);

            if (!fileValidation.IsValid)
            {
                var errorMessages = fileValidation.Errors
                    .Select(e => e.ErrorMessage);
                
                throw new ValidationException(errorMessages);
            }

            try
            {
                using var reader = new StreamReader(request.Request.File.OpenReadStream());
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                });

                csv.Context.RegisterClassMap(new OrderMap());
                var orders = csv.GetRecords<Order>().ToList();

                try
                {
                    _context.Orders.AddRange(orders);
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException ex) when (DatabaseExceptionHelper.IsDuplicateKeyException(ex))
                {
                    throw new DuplicateKeyException(ErrorMessages.DuplicateOrderError, ex);
                }

                return Unit.Value;
            }
            catch (ReaderException ex)
            {
                throw new CsvProcessingException (ErrorMessages.CsvProcessingError, ex);
            }        
        }
    }
}
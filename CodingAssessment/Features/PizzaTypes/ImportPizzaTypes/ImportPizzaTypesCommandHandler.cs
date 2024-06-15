using System.Globalization;
using CodingAssessment.Database;
using CodingAssessment.Mapping.CsvMapping;
using CodingAssessment.Models;
using CodingAssessment.Utilities;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidationException = CodingAssessment.Exceptions.ValidationException;

namespace CodingAssessment.Features.PizzaTypes.ImportPizzaTypes;

/// <summary>
/// Contains the handler for processing the import command.
/// </summary>
public static class ImportPizzaTypesCommandHandler
{
    internal sealed class Handler : IRequestHandler<ImportPizzaTypesCommand, Unit>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ImportPizzaTypesCommand request, CancellationToken cancellationToken)
        {
            var validation = await new ImportPizzaTypesValidation()
                .ValidateAsync(request.PizzaTypesRequest, cancellationToken);

            if (!validation.IsValid)
            {
                var errorMessages = validation.Errors
                    .Select(e => e.ErrorMessage);
                
                throw new ValidationException(errorMessages);
            }

            try
            {
                using var reader = new StreamReader(request.PizzaTypesRequest.File.OpenReadStream());
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                });

                var categories = await _context.PizzaCategories.ToDictionaryAsync(
                    c => c.Name,
                    c => c.Id,
                    StringComparer.OrdinalIgnoreCase,
                    cancellationToken);

                csv.Context.RegisterClassMap(new PizzaTypeMap(categories));

                var pizzaTypes = csv.GetRecords<PizzaType>()
                    .Where(pt => pt.CategoryId != -1)
                    .ToList();

                _context.PizzaTypes.AddRange(pizzaTypes);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorMessages.CsvProcessingError);
            }        
        }        
    }
}
using System.Globalization;
using CodingAssessment.Database;
using CodingAssessment.Exceptions;
using CodingAssessment.Mapping.CsvMapping;
using CodingAssessment.Models;
using CodingAssessment.Utilities;
using CsvHelper;
using CsvHelper.Configuration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidationException = CodingAssessment.Exceptions.ValidationException;

namespace CodingAssessment.Features.Pizzas.ImportPizzas;

/// <summary>
/// Contains the handler for processing the import command.
/// </summary>
public static class ImportPizzasCommandHandler
{
    internal sealed class Handler : IRequestHandler<ImportPizzasCommand, Unit>
    {
        private readonly DatabaseContext _context;
        
        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(ImportPizzasCommand request, CancellationToken cancellationToken)
        {
            var fileValidation = await new ImportPizzasFileValidation()
                .ValidateAsync(request.PizzasRequest, cancellationToken);

            if (!fileValidation.IsValid)
            {
                var errorMessages = fileValidation.Errors
                    .Select(e => e.ErrorMessage);
                
                throw new ValidationException(errorMessages);
            }

            try
            {
                using var reader = new StreamReader(request.PizzasRequest.File.OpenReadStream());
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HeaderValidated = null,
                    MissingFieldFound = null
                });

                var pizzaTypes = await _context.PizzaTypes
                    .Select(x => x.Id)
                    .ToListAsync(cancellationToken);

                csv.Context.RegisterClassMap(new PizzaMap(pizzaTypes));
                
                var pizzas = new List<Pizza>();
                
                await foreach (var pizza in csv.GetRecordsAsync<Pizza>(cancellationToken))
                {
                    var dataValidation = await new ImportPizzasDataValidation()
                        .ValidateAsync(pizza, cancellationToken);

                    if (!dataValidation.IsValid)
                    {
                        var errorMessages = dataValidation.Errors
                            .Select(e => e.ErrorMessage);
                
                        throw new ValidationException(errorMessages);
                    }
                    
                    pizzas.Add(pizza);
                }

                try
                {
                    _context.Pizzas.AddRange(pizzas);
                    await _context.SaveChangesAsync(cancellationToken);

                }
                catch (DbUpdateException ex) when (DatabaseExceptionHelper.IsDuplicateKeyException(ex))
                {
                    throw new DuplicateKeyException(ErrorMessages.DuplicatePizzaTypeError, ex);
                }

                return Unit.Value;
            }
            catch (ReaderException ex)
            {
                if (ex.InnerException is PizzaTypeNotFoundException pizzaTypeNotFoundException)
                {
                    throw new CsvProcessingException
                        (pizzaTypeNotFoundException.Message, pizzaTypeNotFoundException);
                }
                
                throw new CsvProcessingException
                    (ErrorMessages.CsvProcessingError, ex);
            }        
        }
    }
}
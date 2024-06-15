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

namespace CodingAssessment.Features.PizzaTypes.ImportPizzaTypes;

/// <summary>
/// Contains the handler for processing the import command.
/// </summary>
public static class ImportPizzaTypesCommandHandler
{
    /// <summary>
    /// Handler for processing the <see cref="ImportPizzaTypesCommand"/>.
    /// </summary>
    internal sealed class Handler : IRequestHandler<ImportPizzaTypesCommand, Unit>
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Handler"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public Handler(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Handles the import command.
        /// </summary>
        /// <param name="request">The command containing the import request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// <exception cref="ValidationException">Thrown when validation fails.</exception>
        /// <exception cref="DuplicateKeyException">Thrown when a duplicate key error occurs.</exception>
        /// <exception cref="CsvProcessingException">Thrown when an error occurs during CSV processing.</exception>
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

                var pizzaTypes = csv.GetRecords<PizzaType>().ToList();

                if (pizzaTypes.Count is not 0)
                {
                    try
                    {
                        _context.PizzaTypes.AddRange(pizzaTypes);
                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    catch (DbUpdateException ex) when (DatabaseExceptionHelper.IsDuplicateKeyException(ex))
                    {
                        throw new DuplicateKeyException(ErrorMessages.DuplicatePizzaTypeError, ex);
                    }
                }

                return Unit.Value;
            }
            catch (ReaderException ex)
            {
                if (ex.InnerException is CategoryNotFoundException categoryNotFoundException)
                {
                    throw new CsvProcessingException(categoryNotFoundException.Message, categoryNotFoundException);
                }
                
                throw new CsvProcessingException(ErrorMessages.CsvProcessingError, ex);
            }        
        }        
    }
}
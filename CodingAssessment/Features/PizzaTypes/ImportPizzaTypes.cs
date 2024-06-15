using System.Globalization;
using CodingAssessment.Database;
using CodingAssessment.Exceptions;
using CodingAssessment.Mapping.CsvMapping;
using CodingAssessment.Models;
using CodingAssessment.Utilities;
using CsvHelper;
using CsvHelper.Configuration;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ValidationException = CodingAssessment.Exceptions.ValidationException;

namespace CodingAssessment.Features.PizzaTypes;

public static class ImportPizzaTypes
{
    public record Command(Request Request) : IRequest<Unit>;
    public record Request(IFormFile File);

    public class Validation : AbstractValidator<Request>
    {
        public Validation()
        {
            RuleFor(x => x.File)
                .NotNull().WithMessage("File is required.");
            
            RuleFor(x => x.File)
                .Must(ValidationHelpers.BeAValidCsv).WithMessage("Only CSV files are allowed.");
        }
    }
    
    internal sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly DatabaseContext _context;

        public Handler(DatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var validation = await new Validation().ValidateAsync(request.Request, cancellationToken);

            if (!validation.IsValid)
            {
                var errorMessages = validation.Errors.Select(e => e.ErrorMessage);
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
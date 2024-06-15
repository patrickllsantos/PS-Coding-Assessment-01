using CodingAssessment.Exceptions;
using CodingAssessment.Models;
using CodingAssessment.Models.Enums;
using CsvHelper.Configuration;

namespace CodingAssessment.Mapping;

public sealed class PizzaMap : ClassMap<Pizza>
{
    public PizzaMap(List<string> pizzaTypes)
    {
        Map(m => m.Id).Name("pizza_id");
        Map(m => m.PizzaTypeId).Name("pizza_type_id").Convert(row =>
        {
            var pizzaTypeId = row.Row.GetField<string>("pizza_type_id");
            if (pizzaTypes.Contains(pizzaTypeId))
            {
                return pizzaTypeId;
            }

            throw new PizzaTypeNotFoundException($"Pizza type `{pizzaTypeId}` does not exist in the database.");
        });
        Map(m => m.Size).Name("size").Convert(row =>
        {
            var sizeStr = row.Row.GetField<string>("size");
            if (Enum.TryParse<Size>(sizeStr, out var size))
            {
                return size;
            }
            
            throw new InvalidSizeException($"Size `{sizeStr} is an invalid value.");
        });
        Map(m => m.Price).Name("price");
    }
}
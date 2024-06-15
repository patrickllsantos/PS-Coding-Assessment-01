using CodingAssessment.Exceptions;
using CodingAssessment.Models;
using CsvHelper.Configuration;

namespace CodingAssessment.Mapping.CsvMapping;

/// <summary>
/// Defines the mapping of CSV columns to the properties of the <see cref="PizzaType"/> class.
/// </summary>
public sealed class PizzaTypeMap : ClassMap<PizzaType>
{
    public PizzaTypeMap(Dictionary<string, int> categoryLookup)
    {
        Map(m => m.Id).Name("pizza_type_id");
        Map(m => m.Name).Name("name");
        Map(m => m.CategoryId).Name("category").Convert(row =>
        {
            var categoryName = row.Row.GetField("category");
            return categoryLookup.GetValueOrDefault(categoryName, -1);
        });        
        Map(m => m.Ingredients).Name("ingredients");
    }
}

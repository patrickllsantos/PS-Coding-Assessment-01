using CodingAssessment.Exceptions;
using CodingAssessment.Models;
using CsvHelper.Configuration;

namespace CodingAssessment.Mapping.CsvMapping;

/// <summary>
/// Defines the mapping of CSV columns to the properties of the <see cref="PizzaType"/> class.
/// </summary>
public sealed class PizzaTypeMap : ClassMap<PizzaType>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PizzaTypeMap"/> class with the specified category lookup dictionary.
    /// </summary>
    /// <param name="categoryLookup">A dictionary containing category names and their corresponding IDs.</param>
    /// <exception cref="CategoryNotFoundException">Thrown when a category name from the CSV does not exist in the category lookup dictionary.</exception>
    public PizzaTypeMap(Dictionary<string, int> categoryLookup)
    {
        Map(m => m.Id).Name("pizza_type_id");
        Map(m => m.Name).Name("name");
        Map(m => m.CategoryId).Name("category").Convert(row =>
        {
            var categoryName = row.Row.GetField("category");
            if (categoryLookup.TryGetValue(categoryName, out int categoryId))
            {
                return categoryId;
            }

            throw new CategoryNotFoundException($"Category '{categoryName}' does not exist in the database.");
        });        
        Map(m => m.Ingredients).Name("ingredients");
    }
}

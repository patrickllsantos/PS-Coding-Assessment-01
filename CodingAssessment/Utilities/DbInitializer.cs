using CodingAssessment.Database;
using CodingAssessment.Models;

namespace CodingAssessment.Utilities;

public class DbInitializer
{
    public static async void Seed(IApplicationBuilder builder)
    {
        var context = builder.ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<DatabaseContext>();

        try
        {
            if (!context.PizzaCategories.Any())
            {
                var categories = new List<PizzaCategory>()
                {
                    new PizzaCategory { Name = "Classic" },
                    new PizzaCategory { Name = "Chicken" },
                    new PizzaCategory { Name = "Supreme" },
                    new PizzaCategory { Name = "Veggie" },
                };

                context.AddRange(categories);
            }

            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
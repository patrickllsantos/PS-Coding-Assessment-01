using CodingAssessment.Models;
using CsvHelper.Configuration;

namespace CodingAssessment.Mapping;

public sealed class OrderDetailsMap : ClassMap<OrderDetails>
{
    public OrderDetailsMap(HashSet<string> pizzaIds)
    {
        Map(m => m.Id).Name("order_details_id");
        Map(m => m.OrderId).Name("order_id");
        Map(m => m.PizzaId).Name("pizza_id").Convert(row =>
        {
            var pizzaId = row.Row.GetField<string>("pizza_id");
            if (pizzaIds.Contains(pizzaId))
            {
                return pizzaId;
            }
            return string.Empty;
        });
        Map(m => m.Quantity).Name("quantity");
    }
}
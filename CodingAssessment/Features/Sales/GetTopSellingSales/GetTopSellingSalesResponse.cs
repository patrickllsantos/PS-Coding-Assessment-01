namespace CodingAssessment.Features.Sales.GetTopSellingSales;

/// <summary>
/// Represents the response containing the top-selling pizzas.
/// </summary>
public record GetTopSellingSalesResponse(
    List<TopSeller> TopSellers
);

public class TopSeller
{
    /// <summary>
    /// Refers to the name of the pizza
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Refers to the total quantity sold
    /// </summary>
    public int TotalQuantitySold { get; set; }
}
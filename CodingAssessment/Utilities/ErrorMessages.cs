namespace CodingAssessment.Utilities;

/// <summary>
/// Contains error messages used throughout the application.
/// </summary>
public static class ErrorMessages
{
    /// <summary>
    /// Error message for duplicate pizza type.
    /// </summary>
    public static readonly string DuplicatePizzaTypeError = "Duplicate pizza types found in the CSV file.";

    /// <summary>
    /// Error message for duplicate order.
    /// </summary>
    public static readonly string DuplicateOrderError = "Duplicate order found in the CSV file.";
    
    /// <summary>
    /// Error message for CSV processing errors.
    /// </summary>
    public static readonly string CsvProcessingError = "An error occurred while processing the CSV file.";
}

namespace CodingAssessment.Utilities;

public static class ValidationHelpers
{
    /// <summary>
    /// Validates if the given IFormFile is a valid CSV file.
    /// </summary>
    /// <param name="file">The file to validate.</param>
    /// <returns>True if the file is a valid CSV file; otherwise, false.</returns>
    public static bool BeAValidCsv(IFormFile file)
    {
        if (file is null)
        {
            return false;
        }

        var fileExtension = Path.GetExtension(file.FileName);
        return fileExtension.Equals(".csv", StringComparison.OrdinalIgnoreCase);
    }
}
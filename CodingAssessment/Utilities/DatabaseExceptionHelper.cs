using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CodingAssessment.Utilities;

public static class DatabaseExceptionHelper
{
    /// <summary>
    /// Checks if the provided DbUpdateException is caused by a PostgreSQL duplicate key error.
    /// </summary>
    /// <param name="ex">The DbUpdateException to check.</param>
    /// <returns>True if the exception is caused by a duplicate key error; otherwise, false.</returns>
    public static bool IsDuplicateKeyException(DbUpdateException ex)
    {
        return ex.InnerException is PostgresException { SqlState: "23505" };
    }
}

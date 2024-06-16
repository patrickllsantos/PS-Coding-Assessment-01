using CodingAssessment.Database;
using CodingAssessment.Exceptions;
using CodingAssessment.Utilities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DatabaseContext>();
    await context.Database.MigrateAsync();
    DbInitializer.Seed(app);
}
catch (Exception exception)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(exception, "An error occured during migration");
}

app.Run();
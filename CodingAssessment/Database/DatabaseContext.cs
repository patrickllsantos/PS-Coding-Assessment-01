using CodingAssessment.Database.Configurations;
using CodingAssessment.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingAssessment.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
    {
    }

    public DbSet<Pizza> Pizzas => Set<Pizza>();
    public DbSet<PizzaType> PizzaTypes => Set<PizzaType>();
    public DbSet<PizzaCategory> PizzaCategories => Set<PizzaCategory>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderDetails> OrderDetails => Set<OrderDetails>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PizzaConfiguration());
        modelBuilder.ApplyConfiguration(new PizzaTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new PizzaCategoryConfiguration());
    }
}
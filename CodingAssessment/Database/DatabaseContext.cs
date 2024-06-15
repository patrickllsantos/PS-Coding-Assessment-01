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

        modelBuilder.Entity<Pizza>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.PizzaTypeId)
                .IsRequired();

            entity.Property(p => p.Size)
                .IsRequired();

            entity.Property(p => p.Price)
                .IsRequired()
                .HasPrecision(7, 2);

            entity.HasOne(p => p.PizzaType)
                .WithMany(pt => pt.Pizzas)
                .HasForeignKey(p => p.PizzaTypeId);
        });

        modelBuilder.Entity<PizzaType>(entity =>
        {
            entity.HasKey(pt => pt.Id);
            
            entity.Property(pt => pt.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(pt => pt.Ingredients)
                .IsRequired()
                .HasMaxLength(500);

            entity.HasOne(pt => pt.Category)
                .WithMany(c => c.PizzaTypes)
                .HasForeignKey(pt => pt.CategoryId);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.Id);

            entity.Property(o => o.Date)
                .IsRequired();

            entity.Property(o => o.Time)
                .IsRequired();

            entity.HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);
        });

        modelBuilder.Entity<OrderDetails>(entity =>
        {
            entity.HasKey(od => od.Id);

            entity.Property(od => od.OrderId)
                .IsRequired();

            entity.Property(od => od.PizzaId)
                .IsRequired();

            entity.Property(od => od.Quantity)
                .IsRequired();

            entity.HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);

            entity.HasOne(od => od.Pizza)
                .WithMany(p => p.OrderDetails)
                .HasForeignKey(od => od.PizzaId);
        });

        modelBuilder.Entity<PizzaCategory>(entity =>
        {
            entity.HasKey(pc => pc.Id);

            entity.Property(pc => pc.Name)
                .HasMaxLength(50);

            entity.HasMany(pc => pc.PizzaTypes)
                .WithOne(pt => pt.Category)
                .HasForeignKey(pt => pt.CategoryId);
        });
    }
}
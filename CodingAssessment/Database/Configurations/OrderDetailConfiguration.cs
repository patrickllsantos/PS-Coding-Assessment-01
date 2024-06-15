using CodingAssessment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingAssessment.Database.Configurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetails>
{
    public void Configure(EntityTypeBuilder<OrderDetails> builder)
    {
        builder.HasKey(od => od.Id);

        builder.Property(od => od.OrderId)
            .IsRequired();

        builder.Property(od => od.PizzaId)
            .IsRequired();

        builder.Property(od => od.Quantity)
            .IsRequired();

        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId);

        builder.HasOne(od => od.Pizza)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.PizzaId);
    }
}
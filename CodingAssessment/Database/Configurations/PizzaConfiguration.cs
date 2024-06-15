using CodingAssessment.Models;
using CodingAssessment.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodingAssessment.Database.Configurations;

public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
{
    public void Configure(EntityTypeBuilder<Pizza> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.PizzaTypeId)
            .IsRequired();

        builder.Property(p => p.Size)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<Size>());

        builder.Property(p => p.Price)
            .IsRequired()
            .HasPrecision(7, 2);

        builder.HasOne(p => p.PizzaType)
            .WithMany(pt => pt.Pizzas)
            .HasForeignKey(p => p.PizzaTypeId);
    }
}
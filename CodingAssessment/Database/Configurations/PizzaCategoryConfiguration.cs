using CodingAssessment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingAssessment.Database.Configurations;

public class PizzaCategoryConfiguration : IEntityTypeConfiguration<PizzaCategory>
{
    public void Configure(EntityTypeBuilder<PizzaCategory> builder)
    {
        builder.HasKey(pc => pc.Id);

        builder.Property(pc => pc.Name)
            .HasMaxLength(50);

        builder.HasMany(pc => pc.PizzaTypes)
            .WithOne(pt => pt.Category)
            .HasForeignKey(pt => pt.CategoryId);
    }
}
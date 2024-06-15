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
            .IsRequired();
        
        builder.Property(pc => pc.Name)
            .HasMaxLength(50);

        builder.HasMany(pc => pc.PizzaTypes)
            .WithOne(pt => pt.Category)
            .HasForeignKey(pt => pt.CategoryId);

        builder.HasData(
            new PizzaCategory { Id = 1, Name = "Chicken" },
            new PizzaCategory { Id = 2, Name = "Classic" },
            new PizzaCategory { Id = 3, Name = "Supreme" },
            new PizzaCategory { Id = 4, Name = "Veggie" }
        );
    }
}
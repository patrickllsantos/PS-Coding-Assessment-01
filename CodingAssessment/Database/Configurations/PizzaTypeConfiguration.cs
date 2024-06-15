using CodingAssessment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodingAssessment.Database.Configurations;

public class PizzaTypeConfiguration : IEntityTypeConfiguration<PizzaType>
{
    public void Configure(EntityTypeBuilder<PizzaType> builder)
    {
        builder.HasKey(pt => pt.Id);
            
        builder.Property(pt => pt.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(pt => pt.Ingredients)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(pt => pt.Category)
            .WithMany(c => c.PizzaTypes)
            .HasForeignKey(pt => pt.CategoryId);    
    }
}
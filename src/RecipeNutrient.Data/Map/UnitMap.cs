using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Map
{
    public class UnitMap : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(u => u.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(u => u.UpdatedAt).ValueGeneratedOnUpdate();

            builder.HasMany(u => u.RecipeIngredients)
            .WithOne(ri => ri.Unit);
        }
    }
}


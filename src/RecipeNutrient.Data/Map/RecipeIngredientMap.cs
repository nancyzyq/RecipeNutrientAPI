using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Map
{
    public class RecipeIngredientMap : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.Property(ri => ri.Amount).HasPrecision(9, 2);
            builder.Property(ri => ri.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(ri => ri.UpdatedAt).ValueGeneratedOnUpdate();

            builder.HasOne(ri => ri.Recipe)
                    .WithMany(r => r.RecipeIngredients)
                    .HasForeignKey(ri => ri.RecipeId);

            builder.HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            builder.HasOne(ri => ri.Unit)
                .WithMany(u => u.RecipeIngredients)
                .HasForeignKey(ri => ri.UnitId);

        }
    }
}


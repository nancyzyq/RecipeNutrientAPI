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
            builder.Property(r => r.Amount).HasPrecision(9, 2);

            builder.HasOne(r => r.Recipe)
                    .WithMany(x => x.RecipeIngredients)
                    .HasForeignKey(r => r.RecipeId);

            builder.HasOne(r => r.Ingredient)
                .WithMany(x => x.RecipeIngredients)
                .HasForeignKey(x => x.IngredientId);

            builder.HasOne(r => r.Unit)
                .WithMany(x => x.RecipeIngredients)
                .HasForeignKey(x => x.UnitId);

        }
    }
}


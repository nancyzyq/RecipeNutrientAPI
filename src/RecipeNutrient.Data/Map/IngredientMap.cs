using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Map
{
    public class IngredientMap : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(500);
            builder.Property(m => m.Energy).HasPrecision(12, 2);
            builder.Property(m => m.Fat).HasPrecision(12, 2);
            builder.Property(m => m.SaturatedFat).HasPrecision(12, 2);
            builder.Property(m => m.Carbohydrate).HasPrecision(12, 2);
            builder.Property(m => m.Sugar).HasPrecision(12, 2);
            builder.Property(m => m.Sodium).HasPrecision(12, 2);

            builder.HasMany(r => r.Recipes)
            .WithMany(i => i.Ingredients)
            .UsingEntity<RecipeIngredient>(o => o.HasOne(a => a.Recipe).WithMany(x => x.RecipeIngredients),
                            ri => ri.HasOne(a => a.Ingredient).WithMany(y => y.RecipeIngredients));
        }
    }
}


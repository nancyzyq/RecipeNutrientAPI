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
            builder.Property(i => i.Name).HasMaxLength(500);
            builder.Property(i => i.Protein).HasPrecision(12, 2);
            builder.Property(i => i.Energy).HasPrecision(12, 2);
            builder.Property(i => i.Fat).HasPrecision(12, 2);
            builder.Property(i => i.SaturatedFat).HasPrecision(12, 2);
            builder.Property(i => i.Carbohydrate).HasPrecision(12, 2);
            builder.Property(i => i.Sugar).HasPrecision(12, 2);
            builder.Property(i => i.Sodium).HasPrecision(12, 2);
            builder.Property(i => i.Deleted).HasDefaultValue(false);
            builder.Property(i => i.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(i => i.UpdatedAt).ValueGeneratedOnUpdate();

            //builder.HasMany(r => r.Recipes)
            //.WithMany(i => i.Ingredients)
            //.UsingEntity<RecipeIngredient>(o => o.HasOne(a => a.Recipe).WithMany(x => x.RecipeIngredients),
            //                ri => ri.HasOne(a => a.Ingredient).WithMany(y => y.RecipeIngredients));

            //builder.HasMany(i => i.RecipeIngredients)
            //.WithOne(ri => ri.Ingredient);
        }
    }
}


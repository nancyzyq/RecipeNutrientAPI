using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Map
{
    public class RecipeMap : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(500);

            builder.HasMany(r => r.Ingredients)
            .WithMany(i => i.Recipes)
            .UsingEntity<RecipeIngredient>(ri => ri.HasOne(a => a.Ingredient).WithMany(y => y.RecipeIngredients),
                            o => o.HasOne(a => a.Recipe).WithMany(x => x.RecipeIngredients));

            builder.HasOne(r => r.User)
                    .WithMany(t => t.Recipes)
                    .HasForeignKey(t => t.UserId);

            builder.HasOne(r => r.Category)
                    .WithMany(t => t.Recipes)
                    .HasForeignKey(t => t.CategoryId);
        }
    }
}


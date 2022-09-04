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
            builder.Property(r => r.Name).HasMaxLength(500);
            builder.Property(r => r.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(r => r.UpdatedAt).ValueGeneratedOnUpdate();

            //builder.HasMany(r => r.Ingredients)
            //.WithMany(i => i.Recipes)
            //.UsingEntity<RecipeIngredient>(ri => ri.HasOne(a => a.Ingredient).WithMany(y => y.RecipeIngredients),
            //                o => o.HasOne(a => a.Recipe).WithMany(x => x.RecipeIngredients));

            builder.HasOne(r => r.User)
                    .WithMany(u => u.Recipes)
                    .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Category)
                    .WithMany(c => c.Recipes)
                    .HasForeignKey(r => r.CategoryId);
        }
    }
}


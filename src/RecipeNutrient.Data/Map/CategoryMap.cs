using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data.Map
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(250);
            builder.Property(c => c.Deleted).HasDefaultValue(false);
            builder.Property(c => c.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(c => c.UpdatedAt).ValueGeneratedOnUpdate();

            //builder.HasMany(c => c.Recipes)
            //.WithOne(r => r.Category);
        }
    }
}



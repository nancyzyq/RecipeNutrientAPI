using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeNutrient.Data.Model;
namespace RecipeNutrient.Data.Model
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Deleted).HasDefaultValue(false);
            builder.Property(u => u.CreatedAt).ValueGeneratedOnAdd();
            builder.Property(u => u.UpdatedAt).ValueGeneratedOnUpdate();

            builder.HasMany(u => u.Recipes)
                    .WithOne(r => r.User);

            //builder.HasOne(u => u.Role)
            //    .WithMany(r => r.Users)
            //    .HasForeignKey(u => u.RoleId);

            builder.HasOne(u => u.Role)
                    .WithMany()
                    .HasForeignKey(u => u.RoleId);
        }
    }
}


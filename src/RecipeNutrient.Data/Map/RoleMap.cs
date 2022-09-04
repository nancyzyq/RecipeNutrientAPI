using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeNutrient.Data.Model;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.Property(r => r.CreatedAt).ValueGeneratedOnAdd();
        builder.Property(r => r.UpdatedAt).ValueGeneratedOnUpdate();

        builder.HasMany(r => r.Users)
                .WithOne(x => x.Role);
    }
}


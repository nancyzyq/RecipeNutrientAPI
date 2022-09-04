using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using System.Reflection;
using RecipeNutrient.Data.Map;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Data
{
    public class RecipeNutrientDbContext : DbContext
    {
        public RecipeNutrientDbContext(DbContextOptions<RecipeNutrientDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=recipe-nutrient-mysql.co0pcbbqqnjf.us-west-1.rds.amazonaws.com;port=3306;user=admin;password=987604062Steven;database=recipenutrient;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
            //                    type.BaseType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configInstance = Activator.CreateInstance(type);
            //    modelBuilder.ApplyConfiguration(configInstance);
            //}
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new IngredientMap());
            modelBuilder.ApplyConfiguration(new RecipeIngredientMap());
            modelBuilder.ApplyConfiguration(new RecipeMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UnitMap());
            modelBuilder.ApplyConfiguration(new UserMap());


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Category>? Category { get; set; }
        public DbSet<Ingredient>? Ingredient { get; set; }
        public DbSet<Recipe>? Recipe { get; set; }
        public DbSet<RecipeIngredient>? RecipeIngredient { get; set; }
        public DbSet<Role>? Role { get; set; }
        public DbSet<Unit>? Unit { get; set; }
        public DbSet<User>? User { get; set; }


    }
}


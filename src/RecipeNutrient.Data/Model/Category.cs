using System;
namespace RecipeNutrient.Data.Model
{
    public class Category : BaseEntity
    {
        //public Category()
        //{
        //}
        public string Name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }


    }
}


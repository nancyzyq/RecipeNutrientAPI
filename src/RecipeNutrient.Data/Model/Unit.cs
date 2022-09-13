using System;
namespace RecipeNutrient.Data.Model
{
    public class Unit : BaseEntity
    {
        //public Unit()
        //{
        //}
        public string Name { get; set; }
        public bool Deleted { get; set; }

        //public ICollection<Recipe> Recipes { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

    }
}


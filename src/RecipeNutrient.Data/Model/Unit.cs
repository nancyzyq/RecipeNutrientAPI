using System;
namespace RecipeNutrient.Data.Model
{
    public class Unit : BaseEntity
    {
        //public Unit()
        //{
        //}
        public string name { get; set; }

        public ICollection<Recipe> Recipes { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

    }
}


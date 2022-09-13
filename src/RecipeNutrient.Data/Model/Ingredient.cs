using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeNutrient.Data.Model
{
    public class Ingredient : BaseEntity
    {
        //public Ingredient()
        //{
        //}
        public string Name { get; set; }
        public decimal Energy { get; set; }
        public decimal Fat { get; set; }
        public decimal SaturatedFat { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Sugar { get; set; }
        public decimal Sodium { get; set; }
        public bool Deleted { get; set; }

        //public ICollection<Recipe> Recipes { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }

    }
}


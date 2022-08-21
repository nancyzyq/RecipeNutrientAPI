using System;
namespace RecipeNutrient.Data.Model
{
    public class RecipeIngredient : BaseEntity
    {
        //public recioeIngredient()
        //{
        //}
        public decimal Amount { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public int UnitId { get; set; }

        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        public Unit Unit { get; set; }
    }
}


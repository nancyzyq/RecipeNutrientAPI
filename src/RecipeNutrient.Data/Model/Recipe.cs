using System;
using System.Collections.Generic;
namespace RecipeNutrient.Data.Model
{
    public class Recipe : BaseEntity
    {
        //public Recipe()
        //{
        //}
        public string Name { get; set; }
        //public string Energy { get; set; }
        public string Image { get; set; }
        public bool Deleted { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        //public virtual ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}


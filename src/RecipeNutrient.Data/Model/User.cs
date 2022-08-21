using System;
namespace RecipeNutrient.Data.Model
{
    public class User : BaseEntity
    {
        //public User()
        //{
        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}


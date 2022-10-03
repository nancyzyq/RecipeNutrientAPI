using System;
namespace RecipeNutrient.Data.Model
{
    public class Role : BaseEntity
    {
        //public Role()
        //{
        //}
        public string Name { get; set; }
        public bool Deleted { get; set; }

        //public ICollection<User> Users { get; set; }
    }
}


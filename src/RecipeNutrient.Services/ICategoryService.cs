using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Services
{
    public interface ICategoryService
    {
        Task<Category> InsertCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Category category);
        IList<Category> GetCategories();
        Category GetCategoryById(int id);
    }
}


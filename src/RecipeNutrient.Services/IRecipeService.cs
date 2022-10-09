using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Services
{
    public interface IRecipeService
    {
        Task<Recipe> InsertRecipe(Recipe recipe);
        // Task InsertRecipes(IEnumerable<Recipe> recipe);
        Task UpdateRecipe(Recipe recipe);
        Task DeleteRecipe(Recipe recipe);
        IList<Recipe> GetRecipes();
        IList<Recipe> GetRecipesByCategoryId(int categoryId);
        IList<Recipe> GetRecipesByUserId(int useryId);
        Recipe GetRecipeById(int id);
    }
}


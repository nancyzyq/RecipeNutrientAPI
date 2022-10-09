using System;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;

namespace RecipeNutrient.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _recipeRepository;
        private readonly IRepository<RecipeIngredient> _recipeIngredientRepository;

        public RecipeService(IRepository<Recipe> recipeRepository, IRepository<RecipeIngredient> recipeIngredientRepository)
        {
            _recipeRepository = recipeRepository;
            _recipeIngredientRepository = recipeIngredientRepository;
        }
        public async Task<Recipe> InsertRecipe(Recipe recipe)
        {
            return await _recipeRepository.Insert(recipe);
        }
        public async Task UpdateRecipe(Recipe recipe)
        {
            await _recipeRepository.Update(recipe);
            await _recipeIngredientRepository.Delete(r => r.RecipeId == recipe.Id);
            await _recipeIngredientRepository.Insert(recipe.RecipeIngredients.ToList());
        }
        public async Task DeleteRecipe(Recipe recipe)
        {
            recipe.Deleted = true;
            await _recipeRepository.Update(recipe);
        }
        public IList<Recipe> GetRecipes()
        {
            return _recipeRepository.GetEntities(r => r.Deleted == false).ToList();
        }
        public IList<Recipe> GetRecipesByCategoryId(int categoryId)
        {
            return _recipeRepository.GetEntities(r => r.CategoryId == categoryId && r.Deleted == false).ToList();
        }
        public IList<Recipe> GetRecipesByUserId(int userId)
        {
            return _recipeRepository.GetEntities(r => r.UserId == userId && r.Deleted == false).ToList();
        }
        public Recipe GetRecipeById(int id)
        {
            return _recipeRepository.GetEntityById(id);
        }
    }
}


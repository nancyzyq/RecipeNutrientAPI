using System;
using RecipeNutrient.Data.Model;

namespace RecipeNutrient.Services
{
    public interface IIngredientService
    {
        Task<Ingredient> InsertIngredient(Ingredient ingrdient);
        Task InsertIngredients(IEnumerable<Ingredient> ingredients);
        Task UpdateIngredient(Ingredient ingrdient);
        Task DeleteIngredient(Ingredient ingrdient);
        IList<Ingredient> GetIngredients();
        Ingredient GetIngredientById(int id);
    }
}


﻿using System;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Data.Repository;

namespace RecipeNutrient.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IRepository<Ingredient> _ingredientRepository;

        public IngredientService(IRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task InsertIngredient(Ingredient ingrdient)
        {
            await _ingredientRepository.Insert(ingrdient);
        }

        public async Task InsertIngredients(IEnumerable<Ingredient> ingredients)
        {
            await _ingredientRepository.Insert(ingredients);
        }

        public async Task UpdateIngredient(Ingredient ingrdient)
        {
            await _ingredientRepository.Update(ingrdient);
        }

        public async Task DeleteIngredient(Ingredient ingrdient)
        {
            await _ingredientRepository.Delete(ingrdient);
        }

        public IList<Ingredient> GetIngredients()
        {
            return _ingredientRepository.GetList().ToList();
        }

        public Ingredient GetIngredientById(int id)
        {
            return _ingredientRepository.GetEntityById(id);
        }
    }
}

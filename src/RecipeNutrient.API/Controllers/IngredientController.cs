using System;
using Microsoft.AspNetCore.Mvc;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Services;

namespace RecipeNutrient.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult Getingredients()
        {
            IList<Ingredient> ingredients = _ingredientService.GetIngredients();
            return Ok(ingredients);
        }
    }
}


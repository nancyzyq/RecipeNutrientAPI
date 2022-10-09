using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Services;

namespace RecipeNutrient.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public IActionResult GetRecipes()
        {
            IList<Recipe> recipes = _recipeService.GetRecipes();
            return Ok(recipes);
        }

        [HttpGet("categoryid")]
        public IActionResult GetRecipesByCategoryId([FromQuery] int categoryId)
        {
            IList<Recipe> recipes = _recipeService.GetRecipesByCategoryId(categoryId);
            return Ok(recipes);
        }

        [HttpGet("userid")]
        public IActionResult GetRecipesByUserId([FromQuery] int userId)
        {
            IList<Recipe> recipes = _recipeService.GetRecipesByUserId(userId);
            return Ok(recipes);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipe)
        {
            var data = await _recipeService.InsertRecipe(recipe);
            return Ok(data);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe recipe)
        {
            await _recipeService.UpdateRecipe(recipe);
            return Ok(recipe);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteRecipe([FromBody] Recipe recipe)
        {
            await _recipeService.DeleteRecipe(recipe);
            return Ok("Deleted");
        }
    }
}


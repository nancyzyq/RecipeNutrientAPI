using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public IActionResult Getingredients()
        {
            IList<Ingredient> ingredients = _ingredientService.GetIngredients();
            return Ok(ingredients);
        }

        [HttpGet("id")]
        public IActionResult GetIngredientById(int id)
        {
            var data = _ingredientService.GetIngredientById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredient)
        {
            var data = await _ingredientService.InsertIngredient(ingredient);
            return Ok(data);

        }

        [HttpPut("update")]
        public async Task<ActionResult<Ingredient>> UpdateCategory([FromBody] Ingredient ingredient)
        {
            try
            {
                await _ingredientService.UpdateIngredient(ingredient);
                return Ok(ingredient);
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteIngredient([FromBody] Ingredient ingredient)
        {
            await _ingredientService.DeleteIngredient(ingredient);
            return Ok("Deleted");
        }
    }
}


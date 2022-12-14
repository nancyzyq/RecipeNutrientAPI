using System;
using Microsoft.AspNetCore.Mvc;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Services;

namespace RecipeNutrient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            IList<Category> data = _categoryService.GetCategories();
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            var data = await _categoryService.InsertCategory(category);
            return Ok(data);

        }

        [HttpPut("update")]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] Category category)
        {
            await _categoryService.UpdateCategory(category);
            return Ok(category);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteCategory([FromBody] Category category)
        {
            await _categoryService.DeleteCategory(category);
            return Ok("Deleted");
        }
    }
}


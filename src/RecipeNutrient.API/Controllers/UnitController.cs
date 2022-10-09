using System;
using Microsoft.AspNetCore.Mvc;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Services;

namespace RecipeNutrient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }

        public IActionResult getUnits()
        {
            var data = _unitService.GetUnits();
            return Ok(data);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Unit>> CreateUnit([FromBody] Unit unit)
        {
            var data = await _unitService.InsertUnit(unit);
            return Ok(data);
        }

        [HttpPut("update")]
        public async Task<ActionResult<Unit>> UpdateUnit([FromBody] Unit unit)
        {
            await _unitService.UpdateUnit(unit);
            return Ok(unit);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteUnit([FromBody] Unit unit)
        {
            await _unitService.DeleteUnit(unit);
            return Ok("Deleted");
        }
    }
}


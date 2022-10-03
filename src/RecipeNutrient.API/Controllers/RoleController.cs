using System;
using Microsoft.AspNetCore.Mvc;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Services;

namespace RecipeNutrient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Role>> CreateRole([FromBody] Role role)
        {
            var data = await _roleService.InsertRole(role);
            return Ok(data);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteRole([FromBody] Role role)
        {
            await _roleService.DeleteRole(role);
            return Ok("Deleted");
        }
    }
}


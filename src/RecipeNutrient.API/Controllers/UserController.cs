using System;
using Microsoft.AspNetCore.Mvc;
using RecipeNutrient.Data.Model;
using RecipeNutrient.Services;
using RecipeNutrient.Services.Model;

namespace RecipeNutrient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);
        }

        [HttpGet("id")]
        public IActionResult GetUserById(int id)
        {
            var data = _userService.GetUserById(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register([FromBody] User user)
        {
            var data = await _userService.Register(user);
            return Ok(data);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteUser([FromBody] User user)
        {
            await _userService.DeleteUser(user);
            return Ok("Deleted");
        }
    }
}


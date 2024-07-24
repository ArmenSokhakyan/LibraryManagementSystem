using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] UserLoginModel model)
        {
            var token = await _authService.Authenticate(model.Username, model.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { Token  = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            await _authService.Register(model);
            return Ok();
        }
    }
}

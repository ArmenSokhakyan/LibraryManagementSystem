using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusers() 
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id) 
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null) 
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User user) 
        {
            await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user) 
        {
            if (id != user.Id) 
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id) 
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

    }
}

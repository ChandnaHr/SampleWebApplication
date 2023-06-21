using Microsoft.AspNetCore.Mvc;
using SampleWebApplication.Models;
using SampleWebApplication.Services;
using System.Diagnostics;

namespace SampleWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userDetails = await _userService.GetUser(id);

            if (userDetails == null)
            {
                return NotFound();
            }

            return Ok(userDetails);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var createdUser = await _userService.CreateUser(createUserRequest);

            if (createdUser == null)
            {
                return BadRequest("Failed to create user");
            }

            return Created("", createdUser);
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            var registerUser = await _userService.RegisterUser(registerUserRequest);

            if (registerUser == null)
            {
                return BadRequest("Failed to register user");
            }
            return Created("", registerUser);
        }


    }
}
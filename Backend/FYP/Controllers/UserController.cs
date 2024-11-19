using AutoMapper;
using FYP.Data;
using FYP.DTO_s;
using FYP.DTO_s.UserDTOs;
using FYP.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FYP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly ApplicationDbContext _context;
            private readonly IUserService _userService;
            private readonly IMapper _mapper;


            public UserController(ApplicationDbContext context, IMapper mapper, IUserService userService)
            {
                _context = context;
                _mapper = mapper;
                _userService = userService;
            }

            [HttpGet("getallusers")]
            public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
            {
                try
                {
                    // Call the service to get the data
                    var users = await _userService.GetAllUsersAsync();

                    // Return HTTP 200 with the data
                    return Ok(users);
                }
                catch (Exception ex)
                {
                    // Handle errors gracefully
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { message = "An error occurred while fetching users.", error = ex.Message });
                }
            }

            [HttpPost("createuser")]
            public async Task<IActionResult> CreateNewUserAsync([FromBody] CreateUserDTO createUserDTO)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState); // Validate input
                }

                // Validate email
                if (await _userService.IsEmailExistsAsync(createUserDTO.Email))
                {
                    return Conflict(new { message = "A user with the same email already exists." });
                }

                // Validate NIC
                if (await _userService.IsNICExistsAsync(createUserDTO.Nic))
                {
                    return Conflict(new { message = "A user with the same NIC already exists." });
                }

                await _userService.CreateNewUserAsync(createUserDTO);
                return Created("api/users/createuser", new { message = "User created successfully" });
            }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Validate input
            }

            // Call the service to validate credentials
            var isValidUser = await _userService.ValidateUserAsync(loginUserDTO);
            if (!isValidUser)
            {
                return Unauthorized(new { message = "Invalid email or password." });
            }

            return Ok(new { message = "Login successful." });
        }
    }
}

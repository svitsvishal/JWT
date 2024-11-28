using JwtDemo.Models;
using JwtDemo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _tokenService;

        public AuthController(JwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserModel user)
        {
            // Replace this with your user validation logic
            if (user.Username == "vishal" && user.Password == "vishal")
            {
                var token = _tokenService.GenerateToken(user.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }

        [Authorize]
        [HttpGet("secure")]
        public IActionResult SecureEndpoint()
        {
            return Ok("You are authenticated!");
        }
    }
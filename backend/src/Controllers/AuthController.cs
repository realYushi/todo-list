using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using ToDoListAPI.Attributes;
using ToDoListAPI.Models;
using ToDoListAPI.Services;
using ToDoListAPI.Interfaces;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("/register")]
        public IActionResult Register([FromBody] UserDto registration)
        {
            // Implementation for user registration
        }

        [HttpPost("/login")]
        public IActionResult Login([FromBody] UserDto login)
        {
            // Implementation for user login
        }

        [HttpPost("/logout")]
        public IActionResult Logout()
        {
            // Implementation for user logout
        }
    }

}
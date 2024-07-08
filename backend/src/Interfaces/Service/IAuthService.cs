using ToDoListAPI.DTOs;
using Microsoft.AspNetCore.Http;

namespace ToDoListAPI.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(UserDto login, HttpContext httpContext);
        Task<UserDto> Register(UserDto registration);
    }
}
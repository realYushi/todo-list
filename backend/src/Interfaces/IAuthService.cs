
using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
    public interface IAuthService
    {
        UserDto Register(UserDto registration);
        string Login(UserDto login);

        void Logout();
    }
}
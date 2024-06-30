using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
namespace ToDoListAPI.Services

{

    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDTO CreateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUsers(string role, string status)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public UserDTO UpdateUser(string id, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}

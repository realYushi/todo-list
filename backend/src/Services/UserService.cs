using Microsoft.VisualBasic;
using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Interfaces;
using AutoMapper;
namespace ToDoListAPI.Services

{

    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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

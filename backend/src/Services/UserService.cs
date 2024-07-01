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
        public UserDto CreateUser(UserDto user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAllUsers(string role, string status)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public UserDto UpdateUser(string id, UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}

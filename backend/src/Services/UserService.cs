using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.Data;

namespace ToDoListAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public UserDto CreateUser(UserDto user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            User userEntity = _mapper.Map<User>(user);
            _unitOfWork.UserRepository.CreateUser(userEntity); // Pass userId
            _unitOfWork.Save();
            return _mapper.Map<UserDto>(userEntity);
        }

        public bool DeleteUser(string userId)
        {
            if (_unitOfWork.UserRepository.DeleteUser(userId))
            {
                _unitOfWork.Save();
                return true;

            }; // Pass userId
            return false;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            IEnumerable<User> users = _unitOfWork.UserRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto GetUser(string userName, string email, string password)
        {
            User user = _unitOfWork.UserRepository.GetUser(userName, email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return _mapper.Map<UserDto>(user);
            }
            return null; // Handle user not found or password mismatch
        }

        public UserDto UpdateUser(string userId, UserDto user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            User userEntity = _mapper.Map<User>(user);
            User updatedUserEntity = _unitOfWork.UserRepository.UpdateUser(userId, userEntity); // Pass userId
            _unitOfWork.Save();
            return _mapper.Map<UserDto>(updatedUserEntity);
        }
    }
}

using Microsoft.VisualBasic;
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
            User userEntity = _mapper.Map<User>(user);
            _unitOfWork.UserRepository.CreateUser(userEntity);
            UserDto createdUser = _mapper.Map<UserDto>(userEntity);
            _unitOfWork.Save();
            return createdUser;

        }

        public void DeleteUser(string id)
        {
            String userId = id;
            _unitOfWork.UserRepository.DeleteUser(userId);
            _unitOfWork.Save();

        }

        public IEnumerable<UserDto> GetAllUsers(string role, string status)
        {
            String userRole = role;
            String userStatus = status;
            IEnumerable<User> users = _unitOfWork.UserRepository.GetAllUsers(userRole, userStatus);
            return _mapper.Map<IEnumerable<UserDto>>(users);

        }

        public UserDto GetUser(string id)
        {
            String userId = id;
            User user = _unitOfWork.UserRepository.GetUser(userId);
            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUser(string id, UserDto user)
        {
            String userId = id;
            UserDto updatedUser = user;
            User userEntity = _mapper.Map<User>(updatedUser);
            User updatedUserEntity = _unitOfWork.UserRepository.UpdateUser(userId, userEntity);
            _unitOfWork.Save();
            return _mapper.Map<UserDto>(updatedUserEntity);

        }
    }
}

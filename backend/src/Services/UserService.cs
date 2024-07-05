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
            _unitOfWork.UserRepository.CreateUser(userEntity); // Pass userId
            _unitOfWork.Save();
            return _mapper.Map<UserDto>(userEntity);
        }

        public void DeleteUser(string userId)
        {
            _unitOfWork.UserRepository.DeleteUser(userId); // Pass userId
            _unitOfWork.Save();
        }

        public IEnumerable<UserDto> GetAllUsers(string userId)
        {
            IEnumerable<User> users = _unitOfWork.UserRepository.GetAllUsers(userId); // Pass userId
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public UserDto GetUser(string userId)
        {
            User user = _unitOfWork.UserRepository.GetUser(userId); // Pass userId
            return _mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUser(string userId, UserDto user)
        {
            User userEntity = _mapper.Map<User>(user);
            User updatedUserEntity = _unitOfWork.UserRepository.UpdateUser(userId, userEntity); // Pass userId
            _unitOfWork.Save();
            return _mapper.Map<UserDto>(updatedUserEntity);
        }
    }
}

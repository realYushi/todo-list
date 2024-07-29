using ToDoListAPI.DTOs;
using ToDoListAPI.Models;
using ToDoListAPI.Interfaces;
using AutoMapper;

namespace ToDoListAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(UserDto user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            User userEntity = _mapper.Map<User>(user);
            User createdUser = await _userRepository.CreateUserAsync(userEntity);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<bool> DeleteUserAsync(Guid userId)
        {
            return await _userRepository.DeleteUserAsync(userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            IEnumerable<User> users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserAsync(string userName)
        {
            try
            {
                User user = await _userRepository.GetUserAsync(userName);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex) when (ex.Message.Contains("not found"))
            {
                return null;
            }
            catch (Exception ex)
            {
                // Handle the exception or log the error
                Console.WriteLine($"An error occurred while getting the user: {ex.Message}");
                throw; // Rethrow the exception to propagate it to the caller
            }
        }

        public async Task<UserDto> UpdateUserAsync(UserDto user, Guid userId)
        {
            user.UserId = userId;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            User userEntity = _mapper.Map<User>(user);
            User updatedUserEntity = await _userRepository.UpdateUserAsync(userId, userEntity);
            return _mapper.Map<UserDto>(updatedUserEntity);
        }
    }
}
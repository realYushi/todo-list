using ToDoListAPI.DTOs;

namespace ToDoListAPI.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers(string role, string status);
        UserDTO GetUserById(string id);
        UserDTO CreateUser(UserDTO user);
        UserDTO UpdateUser(string id, UserDTO user);
        void DeleteUser(string id);
    }
    public class UserService : IUserService
    {
        private readonly List<UserDTO> _users = new List<UserDTO>();

        public IEnumerable<UserDTO> GetAllUsers(string role, string status)
        {
            return _users.Where(u =>
                (string.IsNullOrEmpty(role) || u.Role == role) &&
                (string.IsNullOrEmpty(status) || u.Status == status)).ToList();
        }

        public UserDTO GetUserById(string id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public UserDTO CreateUser(UserDTO user)
        {
            user.Id = (int.Parse(_users.Max(u => u.Id) ?? "0") + 1).ToString();  // Simple auto-increment for ID
            _users.Add(user);
            return user;
        }

        public UserDTO UpdateUser(string id, UserDTO user)
        {
            var existingUser = GetUserById(id);
            if (existingUser != null)
            {
                _users.Remove(existingUser);
                user.Id = id;  // Ensure the ID is unchanged
                _users.Add(user);
                return user;
            }
            return null;
        }

        public void DeleteUser(string id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _users.Remove(user);
            }
        }
    }
}

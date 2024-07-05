namespace ToDoListAPI.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public String Password { get; set; }

        public string Role { get; set; }
        public string Status { get; set; }
    }
}
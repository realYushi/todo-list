namespace ToDoListAPI.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }
        public string Status { get; set; }
    }
}
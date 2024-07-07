namespace ToDoListAPI.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Role { get; set; } = "User";
        public string Status { get; set; } = "Active";
    }
}
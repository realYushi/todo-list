namespace ToDoListAPI.DTOs;
public class ListDto
{
    // Assuming you have an Id property in your List model
    public int Id { get; set; }

    // Include other properties that you want to expose
    public string Name { get; set; }

    // You might want to include counts or other summary data instead of full navigation properties
    public int TaskCount { get; set; }

    // Optionally include user information if needed
    public string UserName { get; set; }
}
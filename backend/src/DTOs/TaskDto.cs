namespace ToDoListAPI.DTOs;

public class TaskDto
{
    // Assuming you have an Id property in your Task model
    public int Id { get; set; }

    // Include other properties that you want to expose
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    // Optionally include related data as needed, simplified
    public int ListId { get; set; } // Reference to the list this task belongs to
}
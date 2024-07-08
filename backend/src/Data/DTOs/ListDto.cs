namespace ToDoListAPI.DTOs;
public class ListDto
{
    public Guid? ListId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public Guid UserId { get; set; }
    public ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
namespace ToDoListAPI.DTOs;

using System.ComponentModel.DataAnnotations;

public class TaskDto
{
    public Guid? TaskId { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = "";
    public DateTime? DueDate { get; set; }
    public Guid ListId { get; set; }
    public StatusEnum Status { get; set; } = StatusEnum.Pending;
    public Guid UserId { get; set; }
    public byte[]? RowVersion { get; set; }

    public enum StatusEnum
    {
        Pending = 1,
        InProgress = 2,
        Completed = 3
    }
}
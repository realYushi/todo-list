using ToDoListAPI.DTOs;

namespace ToDoListAPI.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> CreateTaskAsync(TaskDto task, Guid userId);
        Task<bool> DeleteTaskAsync(Guid taskId, Guid userId);
        Task<IEnumerable<TaskDto>> GetAllTasksAsync(Guid userId);
        Task<TaskDto> GetTaskAsync(Guid taskId, Guid userId);
        Task<TaskDto> UpdateTaskAsync(Guid id, TaskDto task, Guid userId);
    }
}
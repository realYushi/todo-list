using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAllTasksAsync(Guid userId);
        Task<Models.Task> GetTaskAsync(Guid taskId, Guid userId);
        Task<Models.Task> CreateTaskAsync(Models.Task task, Guid userId);
        Task<Models.Task> UpdateTaskAsync(Guid taskId, Models.Task task, Guid userId);
        Task<bool> DeleteTaskAsync(Guid taskId, Guid userId);
    }
}
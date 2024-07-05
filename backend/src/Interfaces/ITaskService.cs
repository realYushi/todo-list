using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks(String userId);
        TaskDto GetTask(String userId, String id);
        TaskDto CreateTask(TaskDto task, String userId);
        TaskDto UpdateTask(string id, TaskDto task, string userId);
        void DeleteTask(String userId, String id);
    }
}
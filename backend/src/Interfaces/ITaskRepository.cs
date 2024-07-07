using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Models.Task> GetAllTasks(String userId);
        Models.Task GetTask(String id, String userId);
        Models.Task CreateTask(Models.Task task, String userId);
        Models.Task UpdateTask(String id, Models.Task task, String userId);
        bool DeleteTask(String id, String userId);
    }
}
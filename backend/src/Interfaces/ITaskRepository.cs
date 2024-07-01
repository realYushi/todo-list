using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Models.Task> GetAllTasks();
        Models.Task GetTask(String id);
        Models.Task CreateTask(Models.Task task);
        Models.Task UpdateTask(String id, Models.Task task);
        void DeleteTask(String id);
    }
}
using ToDoListAPI.Models;
namespace ToDoListAPI.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Models.Task> GetAllTasks();
        Models.Task GetTask(int id);
        Models.Task CreateTask(Models.Task task);
        Models.Task UpdateTask(int id, Models.Task task);
        void DeleteTask(int id);
    }
}
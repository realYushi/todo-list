using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks();
        TaskDto GetTask(String id);
        TaskDto CreateTask(TaskDto task);
        TaskDto UpdateTask(String id, TaskDto task);
        void DeleteTask(String id);
    }
}
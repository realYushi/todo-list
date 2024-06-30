using ToDoListAPI.DTOs;
namespace ToDoListAPI.Interface
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks();
        TaskDto GetTask(int id);
        TaskDto CreateTask(TaskDto task);
        TaskDto UpdateTask(int id, TaskDto task);
        void DeleteTask(int id);
    }
}
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int id);
        TaskDto CreateTask(TaskDto task);
        void DeleteTask(int id);
    }
    public class TaskService : ITaskService
    {
        private readonly List<TaskDto> _tasks = new List<TaskDto>();

        public IEnumerable<TaskDto> GetAllTasks()
        {
            return _tasks;
        }

        public TaskDto GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public TaskDto CreateTask(TaskDto task)
        {
            task.Id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;  // Simulating ID assignment
            _tasks.Add(task);
            return task;
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}

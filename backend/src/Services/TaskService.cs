using ToDoListAPI.DTOs;
using ToDoListAPI.Interface;
using ToDoListAPI.Interfaces;

namespace ToDoListAPI.Services
{
    public class TaskService : ITaskService
    {
        public TaskDto CreateTask(TaskDto task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public TaskDto GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public TaskDto UpdateTask(int id, TaskDto task)
        {
            throw new NotImplementedException();
        }
    }
}

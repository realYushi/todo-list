using ToDoListAPI.Interfaces;

namespace ToDoListAPI.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Models.Task CreateTask(Models.Task task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(String id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Models.Task> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public Models.Task GetTask(String id)
        {
            throw new NotImplementedException();
        }

        public Models.Task UpdateTask(String id, Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
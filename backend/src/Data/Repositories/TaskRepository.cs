using ToDoListAPI.Data;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ToDoListAPI.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private ToDoListContext context;

        public TaskRepository(ToDoListContext context)
        {
            this.context = context;
        }

        public Models.Task CreateTask(Models.Task task, string userId)
        {
            task.UserId = userId;  // Ensure the UserId is set
            var createdTask = context.Tasks.Add(task);
            return createdTask.Entity;
        }

        public bool DeleteTask(string id, string userId)
        {
            var task = context.Tasks.SingleOrDefault(t => t.Id == id && t.UserId == userId);
            if (task == null)
            {
                return false;
            }
            context.Tasks.Remove(task);
            return true;
        }

        public IEnumerable<Models.Task> GetAllTasks(string userId)
        {
            var tasks = context.Tasks.Where(t => t.UserId == userId).AsQueryable();  // Filter by UserId
            return tasks;
        }

        public Models.Task GetTask(string id, string userId)
        {
            var task = context.Tasks.FirstOrDefault(t => t.Id == id && t.UserId == userId);
            return task;
        }

        public Models.Task UpdateTask(string id, Models.Task task, string userId)
        {
            task.UserId = userId;  // Ensure the UserId is set
            var updatedTask = context.Tasks.Update(task);
            return updatedTask.Entity;
        }
    }
}
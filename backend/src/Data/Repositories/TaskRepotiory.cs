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

        public Models.Task CreateTask(Models.Task task)
        {
            var createdTask = context.Tasks.Add(task);
            return createdTask.Entity;
        }

        public void DeleteTask(String id)
        {
            context.Tasks.Remove(context.Tasks.Find(id));
        }

        public IEnumerable<Models.Task> GetAllTasks()
        {
            var tasks = context.Tasks;
            return tasks;
        }

        public Models.Task GetTask(String id)
        {
            var task = context.Tasks.Find(id);
            return task;
        }

        public Models.Task UpdateTask(String id, Models.Task task)
        {
            var updatedTask = context.Tasks.Update(task);
            return updatedTask.Entity;
        }
    }
}
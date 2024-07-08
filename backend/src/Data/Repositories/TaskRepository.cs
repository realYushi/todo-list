using ToDoListAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ToDoListAPI.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ToDoListContext _context;

        public TaskRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<Models.Task> CreateTaskAsync(Models.Task task, Guid userId)
        {
            var createdTask = await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return createdTask.Entity;
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId, Guid userId)
        {
            var task = await GetTaskByIdAndUserIdAsync(taskId, userId);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Models.Task>> GetAllTasksAsync(Guid userId)
        {
            return await _context.Tasks.Where(t => t.UserId == userId).ToListAsync();
        }

        public async Task<Models.Task> GetTaskAsync(Guid taskId, Guid userId)
        {
            return await GetTaskByIdAndUserIdAsync(taskId, userId);
        }

        public async Task<Models.Task> UpdateTaskAsync(Guid taskId, Models.Task updatedTask, Guid userId)
        {
            var existingTask = await _context.Tasks
                .FirstOrDefaultAsync(t => t.TaskId == taskId && t.UserId == userId);
            if (existingTask == null)
            {
                return null;
            }

            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.Status = updatedTask.Status;
            existingTask.DueDate = updatedTask.DueDate;

            await _context.SaveChangesAsync();

            return existingTask;
        }

        private async Task<Models.Task> GetTaskByIdAndUserIdAsync(Guid taskId, Guid userId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId && t.UserId == userId);
        }
    }
}

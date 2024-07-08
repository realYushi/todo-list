using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.Models;

namespace ToDoListAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDto> CreateTaskAsync(TaskDto task, Guid userId)
        {
            task.UserId = userId;
            Models.Task taskEntity = _mapper.Map<Models.Task>(task);
            Models.Task createdTask = await _taskRepository.CreateTaskAsync(taskEntity, userId);
            return _mapper.Map<TaskDto>(createdTask);
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId, Guid userId)
        {
            return await _taskRepository.DeleteTaskAsync(taskId, userId);
        }

        public async Task<IEnumerable<TaskDto>> GetAllTasksAsync(Guid userId)
        {
            IEnumerable<Models.Task> tasks = await _taskRepository.GetAllTasksAsync(userId);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public async Task<TaskDto> GetTaskAsync(Guid taskId, Guid userId)
        {
            Models.Task task = await _taskRepository.GetTaskAsync(taskId, userId);
            return _mapper.Map<TaskDto>(task);
        }

        public async Task<TaskDto> UpdateTaskAsync(Guid taskId, TaskDto taskDto, Guid userId)
        {
            var existingTask = await _taskRepository.GetTaskAsync(taskId, userId);
            if (existingTask == null)
            {
                return null;
            }

            // Map the DTO to the existing entity
            existingTask.Title = taskDto.Title;
            existingTask.Description = taskDto.Description;
            existingTask.Status = (Models.Task.StatusEnum)taskDto.Status;
            existingTask.DueDate = taskDto.DueDate;

            var updatedTask = await _taskRepository.UpdateTaskAsync(taskId, existingTask, userId);
            return _mapper.Map<TaskDto>(updatedTask);
        }
    }
}

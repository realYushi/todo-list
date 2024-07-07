using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using AutoMapper;
using Task = ToDoListAPI.Models.Task;
namespace ToDoListAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public TaskDto CreateTask(TaskDto task, string userId)
        {
            Task taskEntity = _mapper.Map<Task>(task);
            taskEntity.UserId = userId;  // Set the UserId for the task
            _unitOfWork.TaskRepository.CreateTask(taskEntity, userId);
            _unitOfWork.Save();
            return _mapper.Map<TaskDto>(taskEntity);
        }

        public bool DeleteTask(string id, string userId)
        {
            return _unitOfWork.TaskRepository.DeleteTask(id, userId);
        }

        public IEnumerable<TaskDto> GetAllTasks(string userId)
        {
            IEnumerable<Task> tasks = _unitOfWork.TaskRepository.GetAllTasks(userId);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public TaskDto GetTask(string id, string userId)
        {
            Task task = _unitOfWork.TaskRepository.GetTask(id, userId);
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto UpdateTask(string id, TaskDto task, string userId)
        {
            Task taskEntity = _mapper.Map<Models.Task>(task);
            Task updatedTask = _unitOfWork.TaskRepository.UpdateTask(id, taskEntity, userId);
            _unitOfWork.Save();
            return _mapper.Map<TaskDto>(updatedTask);
        }
    }
}
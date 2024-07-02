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

        public TaskService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public TaskDto CreateTask(TaskDto task)
        {
            Task taskEntity = _mapper.Map<Task>(task);
            _unitOfWork.TaskRepository.CreateTask(taskEntity);
            TaskDto createdTask = _mapper.Map<TaskDto>(taskEntity);
            _unitOfWork.Save();
            return createdTask;
        }

        public void DeleteTask(string id)
        {
            _unitOfWork.TaskRepository.DeleteTask(id);
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            IEnumerable<Models.Task> tasks = _unitOfWork.TaskRepository.GetAllTasks();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public TaskDto GetTask(string id)
        {
            Task task = _unitOfWork.TaskRepository.GetTask(id);
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto UpdateTask(string id, TaskDto task)
        {
            Task taskEntity = _mapper.Map<Models.Task>(task);
            Task updatedTask = _unitOfWork.TaskRepository.UpdateTask(id, taskEntity);
            _unitOfWork.Save();
            return _mapper.Map<TaskDto>(updatedTask);
        }
    }
}
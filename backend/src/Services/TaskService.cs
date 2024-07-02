using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using AutoMapper;
using ToDoListAPI.Models;
using Task = ToDoListAPI.Models.Task;
namespace ToDoListAPI.Services
{
    public class TaskService : ITaskService
    {
        readonly ITaskRepository _TaskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _TaskRepository = taskRepository;
            _mapper = mapper;

        }
        public TaskDto CreateTask(TaskDto task)
        {
            TaskDto taskDto = task;
            Task taskEntity = _mapper.Map<Task>(taskDto);
            _TaskRepository.CreateTask(taskEntity);
            TaskDto createdTask = _mapper.Map<TaskDto>(taskEntity);
            return createdTask;

        }

        public void DeleteTask(String id)
        {
            String taskId = id;
            _TaskRepository.DeleteTask(taskId);

        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            IEnumerable<Models.Task> tasks = _TaskRepository.GetAllTasks();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);

        }

        public TaskDto GetTask(String id)
        {
            String taskId = id;
            Task task = _TaskRepository.GetTask(taskId);
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto UpdateTask(String id, TaskDto task)
        {
            String taskId = id;
            TaskDto taskDto = task;
            Task taskEntity = _mapper.Map<Models.Task>(taskDto);
            Task updatedTask = _TaskRepository.UpdateTask(taskId, taskEntity);
            return _mapper.Map<TaskDto>(updatedTask);
        }
    }
}

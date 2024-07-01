using ToDoListAPI.DTOs;
using ToDoListAPI.Interfaces;
using AutoMapper;
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

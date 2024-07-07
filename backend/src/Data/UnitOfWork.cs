using System;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
namespace ToDoListAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ToDoListContext _context;
        private readonly ITaskRepository _taskRepository;
        private readonly IListRepository _listRepository;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(ToDoListContext context, ITaskRepository taskRepository, IListRepository listRepository, IUserRepository userRepository)
        {
            _context = context;


            _taskRepository = taskRepository;

            _listRepository = listRepository;
            _userRepository = userRepository;
        }
        public ITaskRepository TaskRepository => _taskRepository;
        public IListRepository ListRepository => _listRepository;
        public IUserRepository UserRepository => _userRepository;

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}

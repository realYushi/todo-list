using System;
using ToDoListAPI.Interfaces;
using ToDoListAPI.Models;
using ToDoListAPI.Repositories;
namespace ToDoListAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ToDoListContext _context;
        private Lazy<ITaskRepository> _taskRepository;
        private Lazy<IListRepository> _listRepository;
        private Lazy<IUserRepository> _userRepository;

        public UnitOfWork(ToDoListContext context)
        {
            _context = context;
            _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(_context));
            _listRepository = new Lazy<IListRepository>(() => new ListRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(_context));
        }

        public ITaskRepository TaskRepository => _taskRepository.Value;
        public IListRepository ListRepository => _listRepository.Value;
        public IUserRepository UserRepository => _userRepository.Value;

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

using ToDoListAPI.Interfaces;

namespace ToDoListAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ITaskRepository TaskRepository { get; }
        IListRepository ListRepository { get; }
        IUserRepository UserRepository { get; }
        void Save();
        void Dispose();
    }
}
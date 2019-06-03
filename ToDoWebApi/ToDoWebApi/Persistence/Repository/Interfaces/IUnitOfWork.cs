using ToDoWebApi.Persistence.Repository.Interfaces.Repository;

namespace ToDoWebApi.Persistence.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDoRepository { get; }
    }
}

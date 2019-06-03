using ToDoWebApi.Persistence.Repository;
using ToDoWebApi.Persistence.Repository.Interfaces;
using ToDoWebApi.Persistence.Repository.Interfaces.Repository;

namespace ToDoWebApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IToDoRepository ToDoRepository { get; }

        public UnitOfWork(ToDoContext context)
        {
            ToDoRepository = new ToDoRepository(context);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApi.Models;
using ToDoWebApi.Persistence.Repository.Interfaces;
using ToDoWebApi.Persistence.Repository.Interfaces.Repository;

namespace ToDoWebApi.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IToDoRepository _toDoRepository;
        public UnitOfWork(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task<IEnumerable<ToDoDto>> GetAllToDos()
        {
            return await _toDoRepository.GetAllToDos();
        }

    }
}

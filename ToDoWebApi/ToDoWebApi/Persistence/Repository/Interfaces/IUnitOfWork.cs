using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApi.Models;

namespace ToDoWebApi.Persistence.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task<IEnumerable<ToDoDto>> GetAllToDos();
    }
}

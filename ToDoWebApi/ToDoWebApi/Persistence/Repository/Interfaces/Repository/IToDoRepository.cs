using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoWebApi.Models;

namespace ToDoWebApi.Persistence.Repository.Interfaces.Repository
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDoDto>> GetAllToDos();
    }
}

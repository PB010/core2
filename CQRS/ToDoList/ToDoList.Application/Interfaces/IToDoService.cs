using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.ToDos.Models;

namespace ToDoList.Application.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDto>> GetAllToDos();
        Task CreateNewTodo(ToDoForCreationDto dto);
    }
}

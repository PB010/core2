using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Dtos;

namespace ToDoList.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDto>> GetAllToDos();
        Task CreateNewTodo(ToDoForCreationDto dto);
    }
}

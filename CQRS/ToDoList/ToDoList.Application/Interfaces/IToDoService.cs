using System.Threading.Tasks;

namespace ToDoList.Application.Interfaces
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDto>> GetAllToDos();
        Task CreateNewTodo(ToDoForCreationDto dto);
    }
}

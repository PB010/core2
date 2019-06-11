namespace ToDoList.Shared
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoDto>> GetAllToDos();
        Task CreateNewTodo(ToDoForCreationDto dto);
    }
}

using ToDoList.Persistence.Models;

namespace ToDoList.Application.ToDos.Models
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ToDoTime { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public ToDoStatus Status { get; set; }
        public ToDoPriorities ToDoPriority { get; set; }
    }
}

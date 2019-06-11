using System;

namespace ToDoList.Persistence.Models
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ToDoTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ToDoStatus Status { get; set; }
        public int ToDoPrioritiesId { get; set; }
        public ToDoPriorities ToDoPriority { get; set; }

    }
}

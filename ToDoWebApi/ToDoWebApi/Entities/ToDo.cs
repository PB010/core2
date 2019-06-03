using System;

namespace ToDoWebApi.Entities
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

        public string GetStatus()
        {
            return Enum.GetName(typeof(ToDoStatus), Status);
        }

        public string GetTime()
        {
            return ToDoTime.ToString("dd MMM HH:mm");
        }

        public string CreatedAtConverter()
        {
            return CreatedAt.ToString("dd MMM HH:mm");
        }

        public string UpdatedAtConverter()
        {
            return UpdatedAt != null ? UpdatedAt?.ToString("dd MMM HH:mm") : "";
        }

        public string PriorityName()
        {
            return ToDoPriority.Name;
        }
    }
}

using System.Collections.Generic;
using ToDoList.Dtos;
using ToDoList.Interfaces;
using ToDoList.Persistence.Models;

namespace ToDoList.ToDos.Queries
{
    public class GetAllToDosQuery : IQuery<List<ToDoDto>>
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

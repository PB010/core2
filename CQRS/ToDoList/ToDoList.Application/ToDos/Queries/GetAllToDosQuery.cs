using System;
using System.Collections.Generic;
using ToDoList.Application.Interfaces;
using ToDoList.Application.ToDos.Models;
using ToDoList.Persistence.Models;

namespace ToDoList.Application.ToDos.Queries
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

    public class GetAllToDosQueryHandler : IQueryHandler<GetAllToDosQuery, List<ToDoDto>>
    {
        private readonly IToDoService _toDoService;

        public GetAllToDosQueryHandler(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }
        public List<ToDoDto> Handle(GetAllToDosQuery query)
        {
            throw new Exception();
        }
    }
}

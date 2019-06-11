using System;
using System.Collections.Generic;
using ToDoList.Dtos;
using ToDoList.Interfaces;
using ToDoList.ToDos.Queries;

namespace ToDoList.ToDos.Handlers
{
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

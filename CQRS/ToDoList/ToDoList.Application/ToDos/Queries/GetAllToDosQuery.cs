using System.Collections.Generic;
using ToDoList.Application.Interfaces;
using ToDoList.Application.ToDos.Models;

namespace ToDoList.Application.ToDos.Queries
{
    public class GetAllToDosQuery : IQuery<List<ToDoDto>>
    {
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
            return 
        }
    }
}

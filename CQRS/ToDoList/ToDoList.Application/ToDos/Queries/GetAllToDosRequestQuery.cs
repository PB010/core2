using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Application.ToDos.Models;

namespace ToDoList.Application.ToDos.Queries
{
    public class GetAllToDosRequestQuery : IRequest<IEnumerable<ToDoDto>>
    {
    }
        
    public class GetAllToDosRequestHandler : IRequestHandler<GetAllToDosRequestQuery, IEnumerable<ToDoDto>>
    {
        private readonly IToDoService _toDoService;

        public GetAllToDosRequestHandler(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public async Task<IEnumerable<ToDoDto>> Handle(GetAllToDosRequestQuery request,
            CancellationToken cancellationToken)
        {
            var toDosFromDb = await _toDoService.GetAllToDos();

            return toDosFromDb.Select(Mapper.Map<ToDoDto>);
        }
    }
}
    
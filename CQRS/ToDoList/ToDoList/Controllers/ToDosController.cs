using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.ToDos.Models;
using ToDoList.Application.ToDos.Queries;

namespace ToDoList.Controllers
{
    [Route("/api/toDos/")]
    public class ToDosController : BaseController
    {
        public ToDosController(IMediator mediator) : base(mediator)
        {
        }
    

        [HttpGet]
        public async Task<IEnumerable<ToDoDto>> GetAllToDos()
        {
            return await _mediator.Send(new GetAllToDosRequestQuery());
        }
    }
}

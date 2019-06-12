using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Controllers
{
    public class BaseController : Controller
    {
        internal readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}

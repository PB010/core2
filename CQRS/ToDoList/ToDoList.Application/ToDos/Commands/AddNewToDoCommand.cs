using FluentValidation;
using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Application.ToDos.Models;


namespace ToDoList.Application.ToDos.Commands
{
    public class AddNewToDoCommand : IRequest<ToDoDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ToDoTime { get; set; }
        public int ToDoPrioritiesId { get; set; }

        public DateTime ConvertTime()
        {
            return DateTime.Parse(ToDoTime);
        }
    }

    public class AddNewToDoHandler : IRequestHandler<AddNewToDoCommand, ToDoDto>
    {
        private readonly IToDoService _service;

        public AddNewToDoHandler(IToDoService service)
        {
            _service = service;
        }
        //protected override Task Handle(AddNewToDoCommand request, CancellationToken cancellationToken)
        //{
        //    _service.CreateNewTodo(request);
        //    if (string.IsNullOrWhiteSpace(request.Name) ||
        //        string.IsNullOrWhiteSpace(request.Description) ||
        //        string.IsNullOrWhiteSpace(request.ToDoTime) ||
        //        request.ToDoPrioritiesId < 1 && request.ToDoPrioritiesId > 3)
        //        return Task.
        //
        //    return Task.CompletedTask; 
        //}
        public async Task<ToDoDto> Handle(AddNewToDoCommand request, CancellationToken cancellationToken)
        {

                var errorBuilder = new StringBuilder();
                errorBuilder.AppendLine("Invalid order, reason: ");
            
            return await _service.CreateNewTodo(request);
        }
    }

    public class AddNewToDoValidation : AbstractValidator<AddNewToDoCommand>
    {
        public AddNewToDoValidation()
        {
            RuleFor(r => r.Name).NotNull().WithMessage("Name is required");
            RuleFor(r => r.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(r => r.ToDoPrioritiesId).NotEmpty().WithMessage("Priority is required");
            RuleFor(r => r.ToDoTime).NotEmpty().WithMessage("Time is required");
        }

    }
}

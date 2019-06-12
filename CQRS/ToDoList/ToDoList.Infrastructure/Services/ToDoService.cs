using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Application.Interfaces;
using ToDoList.Application.ToDos.Commands;
using ToDoList.Application.ToDos.Models;
using ToDoList.Persistence;
using ToDoList.Persistence.Models;

namespace ToDoList.Infrastructure.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ToDoDbContext _context;

        public ToDoService(ToDoDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ToDo>> GetAllToDos()
        {
            return await _context.ToDos
                .Include(t => t.ToDoPriority)
                .ToListAsync();
        }

        public async Task<ToDoDto> CreateNewTodo(AddNewToDoCommand command)
        {
            var addedToDo = Mapper.Map<ToDo>(command);

            _context.ToDos.Add(addedToDo);
            await _context.SaveChangesAsync();

            return  Mapper.Map<ToDoDto>(addedToDo);
        }
    }

}

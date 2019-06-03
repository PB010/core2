using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoWebApi.Models;
using ToDoWebApi.Persistence.Repository.Interfaces.Repository;

namespace ToDoWebApi.Persistence.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ToDoDto>> GetAllToDos()
        {
            var toDosFromDb = _context.ToDos.OrderBy(t => t.ToDoTime)
                .Include(t => t.ToDoPriority)
                .ToList();
            var toDosToReturn = Mapper.Map<IEnumerable<ToDoDto>>(toDosFromDb);

            return  toDosToReturn;
        }
    }
}
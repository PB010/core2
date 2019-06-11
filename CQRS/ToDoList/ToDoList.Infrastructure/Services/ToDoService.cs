using ToDoList.Persistence;

namespace ToDoList.Infrastructure.Services
{
    public class ToDoService
    {
        private readonly ToDoDbContext _context;

        public ToDoService(ToDoDbContext context)
        {
            _context = context;
        }
    }
}

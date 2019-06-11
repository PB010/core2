using Microsoft.EntityFrameworkCore;
using ToDoList.Persistence.EntityConfiguration;
using ToDoList.Persistence.Models;

namespace ToDoList.Persistence
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        :base(options)
        {
            
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoPriorities> ToDoPriorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoPrioritiesConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

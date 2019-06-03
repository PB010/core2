using Microsoft.EntityFrameworkCore;
using ToDoWebApi.Entities.EntityConfiguration;

namespace ToDoWebApi.Entities
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
        : base(options)
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

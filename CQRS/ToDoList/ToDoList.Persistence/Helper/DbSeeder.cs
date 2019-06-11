using Microsoft.EntityFrameworkCore;

namespace ToDoList.Persistence.Helper
{
    public class DbSeeder
    {
        public static void Migrate(ToDoDbContext context)
        {
            context.Database.Migrate();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ToDoWebApi.Entities;

namespace ToDoWebApi.Persistence
{
    public class DbSeeder
    {
        public static void SeedDb(ToDoContext context)
        {
            context.Database.Migrate();
        }

       
    }
}

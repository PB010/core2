using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ToDoList.Persistence.Helper
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDoDbContext>
    {
        public ToDoDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ToDoDbContext>();

            var connectionString = configuration["ConnectionString"];

            builder.UseSqlServer(connectionString);

            return new ToDoDbContext(builder.Options);
        }
    }
}

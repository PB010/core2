using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using ToDoWebApi.Entities;

namespace ToDoWebApi.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ToDoContext>
    {
        public ToDoContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var builder = new DbContextOptionsBuilder<ToDoContext>();
            
            var connectionString = configuration["connectionString:toDoConnectionString"];
            
            builder.UseSqlServer(connectionString);
            
            return new ToDoContext(builder.Options);
        }
    }
}

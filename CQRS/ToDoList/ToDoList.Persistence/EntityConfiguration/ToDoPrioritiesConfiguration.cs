using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Persistence.Models;

namespace ToDoList.Persistence.EntityConfiguration
{
    public class ToDoPrioritiesConfiguration : IEntityTypeConfiguration<ToDoPriorities>
    {
        public void Configure(EntityTypeBuilder<ToDoPriorities> builder)
        {
            builder.HasKey(b => b.Id);


            builder.Property(b => b.Id)
                .IsRequired();

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasData(
                new ToDoPriorities
                {
                    Id = 1,
                    Name = "Low"
                },
                new ToDoPriorities
                {
                    Id = 2,
                    Name = "Normal"
                },
                new ToDoPriorities
                {
                    Id = 3,
                    Name = "High"
                });
        }
    }
}

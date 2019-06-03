using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ToDoWebApi.Entities.EntityConfiguration
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(b => b.Description)
                .HasMaxLength(1000);

            builder.Property(b => b.ToDoTime)
                .IsRequired();

            builder.Property(b => b.CreatedAt)
                .IsRequired();

            builder.Property(b => b.Status)
                .IsRequired();

            builder.HasData(
                new ToDo
                {
                    Id = 1,
                    Name = "Check task status",
                    Description = "Today is the last day to check the status of X task.",
                    ToDoTime = Convert.ToDateTime("06 Jun 2019 20:00"),
                    CreatedAt = DateTime.Now,
                    Status = ToDoStatus.Open,
                    ToDoPrioritiesId = 3
                },
                new ToDo
                {
                    Id = 2,
                    Name = "Meeting",
                    Description = "Meeting at X place with Y people.",
                    ToDoTime = Convert.ToDateTime("13 Jun 2019 10:00"),
                    CreatedAt = DateTime.Now,
                    Status = ToDoStatus.Open,
                    ToDoPrioritiesId = 1
                },
                new ToDo
                {
                    Id = 3,
                    Name = "New episode",
                    Description = "Watch the new episode of X.",
                    ToDoTime = Convert.ToDateTime("09 Jun 2019 22:00"),
                    CreatedAt = DateTime.Now,
                    Status = ToDoStatus.Open,
                    ToDoPrioritiesId = 2
                });
        }
    }
}

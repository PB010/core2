using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using ToDoList.Application.Interfaces;
using ToDoList.Application.ToDos.Commands;
using ToDoList.Application.ToDos.Models;
using ToDoList.Application.ToDos.Queries;
using ToDoList.Infrastructure.Services;
using ToDoList.Persistence;
using ToDoList.Persistence.Helper;
using ToDoList.Persistence.Models;

namespace ToDoList
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ToDoDbContext>(options =>
                options.UseSqlServer(_configuration["ConnectionString:mediatrConnection"],
                    b => b.MigrationsAssembly(typeof(ToDoDbContext)
                        .GetTypeInfo().Assembly.GetName().Name)));

            services.AddMediatR(typeof(GetAllToDosRequestHandler).Assembly);
            services.AddScoped<IToDoService, ToDoService>();
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddNewToDoValidation>());
            //.AddFluent
            //.AddFluentValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ToDoDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DbSeeder.Migrate(context);
            }

#pragma warning disable 618
            Mapper.Initialize(cfg =>
#pragma warning restore 618
            {
                cfg.CreateMap<ToDo, ToDoDto>().ForMember(dest => dest.ToDoPriority, opt =>
                    opt.MapFrom(src => src.ToDoPriority.Name))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 
                        src.Status.ToString()))
                    .ForMember(dest => dest.ToDoTime, opt => opt.MapFrom(src => 
                        src.ToDoTime.ToString("dd MMM yy HH:mm")))
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src =>
                        src.CreatedAt.ToString("dd MMM yy HH:mm")));
                cfg.CreateMap<AddNewToDoCommand, ToDo>().ForMember(dest => dest.ToDoTime,
                        opt => opt.MapFrom(src => src.ConvertTime()))
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(
                        src => DateTime.Now))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(
                        src => ToDoStatus.Open));
            });

            app.UseMvc();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}

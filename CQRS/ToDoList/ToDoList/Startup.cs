﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using ToDoList.Application.Interfaces;
using ToDoList.Application.ToDos.Models;
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
                options.UseSqlServer(_configuration["connectionString:toDoConnectionString"],
                    b => b.MigrationsAssembly(typeof(ToDoDbContext)
                        .GetTypeInfo().Assembly.GetName().Name)));

            services.AddMediatR(typeof(Startup));
            services.AddScoped<IToDoService, ToDoService>();
            services.AddMvc();
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
                cfg.CreateMap<ToDo, ToDoDto>();
                cfg.CreateMap<ToDoForCreationDto, ToDo>().ForMember(dest => dest.ToDoTime,
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

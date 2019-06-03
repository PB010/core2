using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoWebApi.Entities;
using ToDoWebApi.Models;
using ToDoWebApi.Persistence;
using ToDoWebApi.Persistence.Repository;
using ToDoWebApi.Persistence.Repository.Interfaces;
using ToDoWebApi.Persistence.Repository.Interfaces.Repository;

namespace ToDoWebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<ToDoContext>(options =>
                options.UseSqlServer(_configuration["connectionString:toDoConnectionString"],
                    b => b.MigrationsAssembly(typeof(ToDoContext)
                        .GetTypeInfo().Assembly.GetName().Name)));

            services.AddScoped<IToDoRepository, ToDoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ToDoContext toDoContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                DbSeeder.SeedDb(toDoContext);
            }
            else
            {
                app.UseHsts();
            }

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ToDo, ToDoDto>().ForMember(dest => dest.Status,
                        opt => opt.MapFrom(src => src.GetStatus()))
                    .ForMember(dest => dest.Time, opt => opt.MapFrom(
                        src => src.GetTime()))
                    .ForMember(dest => dest.Created, opt => opt.MapFrom(
                        src => src.CreatedAtConverter()))
                    .ForMember(dest => dest.Updated, opt => opt.MapFrom(
                        src => src.UpdatedAtConverter()))
                    .ForMember(dest => dest.Priority, opt => opt.MapFrom(
                        src => src.PriorityName()));
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

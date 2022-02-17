using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using Domain.Repository_interfaces;
using Persistence;
using Persistence.Repositories;
using Services.Abstractions.Servive_interfaces;
using Services.Mappers;
using Services.Services;
using WebApplication2.Extensions;
using WebApplication2.Filters;
using WebApplication2.Middlewares;

namespace WebApplication2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            //services.AddTransient<ILifeTimeService, LifeTimeService>();
            //services.AddScoped<ILifeTimeService, LifeTimeService>();
            services.AddSingleton<ILifeTimeService, LifeTimeService>();

            services.AddLogging(config =>
            {
                config.AddFile(@"C:\Users\tillichova\Documents\Work\Logs.txt");
                config.SetMinimumLevel(LogLevel.Error);
            });

            services.AddDbContext<ApplicationDBContext>(options => options.UseMySql(Configuration.GetConnectionString("TestDatabase"), new MySqlServerVersion(new Version(8, 0, 11))));

            
            services.AddControllers(options => options.Filters.Add<CustomActionFilter>());

            services.AddSwaggerGen(c =>
            {
                var titleBase = "Lecture5.Api";

                c.SwaggerDoc("v1", new OpenApiInfo { Title = titleBase, Version = "v1" });

                c.EnableAnnotations();
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseInitializeDatabase();

            //app.UseMiddleware<TestMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<TestMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Lecture5.Api v1");
            });
        }
    }
}

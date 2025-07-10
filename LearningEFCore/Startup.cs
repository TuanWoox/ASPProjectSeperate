using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Business;
using Common.Interfaces;
using Data;
using Common.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Common.DbEntities.Identities;

namespace LearningEFCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(
                        Configuration.GetConnectionString("DefaultConnection"),
                        ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection")),
                        mysqlOptions =>
                        {
                            mysqlOptions.MigrationsAssembly("LearningEFCore");
                        })
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
            );

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IRoleBusiness, RoleBusiness>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LearningEFCore", Version = "v1" });
            });
        }

        public void LearningEntityFrameWorkdCore(DatabaseContext dbContext)
        {
            List<Blog> blogs = dbContext.Blogs.ToList();
            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog ID: {blog.BlogId}, URL: {blog.Url}");
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //LearningEntityFrameWorkdCore(dbContext);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LearningEFCore v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedRole(app.ApplicationServices);
            SeedUser(app.ApplicationServices);
        }
        public async void SeedUser(IServiceProvider serviceProvider)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var userBusiness = scope.ServiceProvider.GetRequiredService<IUserBusiness>();
                    await userBusiness.InitUser();
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
        public async void SeedRole(IServiceProvider serviceProvider)
        {
            try
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var roleBusiness = scope.ServiceProvider.GetRequiredService<IRoleBusiness>();
                    await roleBusiness.InitRole();
                }
            } catch(Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}

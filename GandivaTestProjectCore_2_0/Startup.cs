using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GandivaTestProject
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
            services.AddMvc();
            services.AddScoped<IGenericRepository<User, int>, UserRepository>();
            services.AddScoped<IGenericRepository<Task, int>, TaskRepository>();
            services.AddScoped<IGenericRepository<Comment, int>, CommentRepository>();
            services.AddDbContext<TaskManagerDbContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("TaskManagerContext")));
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            IocContainer.Provider = (ServiceProvider)serviceProvider;
            var dbContext = IoC.TaskManagerDbContext;
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            dbContext.CreateSampleData();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Task}/{action=Index}/{id?}");
            });
        }
    }
}

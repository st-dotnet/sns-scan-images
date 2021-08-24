using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SNS.Data.DbContexts;
using SNS.Data.Utilities;
using SNS.Services.Interfaces;
using SNS.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SNSDashboard
{
    public class Startup
    {
        private IWebHostEnvironment _env { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        } 
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IScanImagesService, ScanImagesService>();

            services.AddRazorPages();

            var connectionString = Configuration.GetConnectionString("Ultra")
                                         .Replace("{Path}", _env.ContentRootPath);

            var options = Configuration.GetSection("Settings").Get<Settings>();

            services.AddSingleton(options);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<ScanImagesContext>(options =>
             options.UseSqlServer(connectionString));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My Test1 Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}

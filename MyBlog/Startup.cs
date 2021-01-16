using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBlog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog
{
    public class Startup
    {
        public IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();
        }
    }
}

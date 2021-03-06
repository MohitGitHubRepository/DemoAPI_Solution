﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Service;
using DemoAPI.Core.Contracts;
using DemoAPI.DataAccess.SQL;
using DemoAPI.Models;
using DemoAPI.Services.UserService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Authentication
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
            });
            services.AddOptions();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IRepository<User>, SQLRepository<User>>();
            services.AddScoped<IRepository<User>, SQLRepository<User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

using DemoAPI.Core.Contracts;
using DemoAPI.Core.Contracts.ServiceContract;
using DemoAPI.Core.Model;
using DemoAPI.DataAccess.SQL;
using DemoAPI.Models;
using DemoAPI.Services;
using DemoAPI.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace DemoAPI
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
             this.ValidateToken(Configuration, services);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
            });
            services.AddOptions();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<IRepository<User>, SQLRepository<User>>();
            services.AddScoped<IRepository<Survey>, SQLRepository<Survey>>();
            services.AddScoped<IRepository<Feedback>, SQLRepository<Feedback>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISurveyContract, SurveyService>();
            services.AddScoped<IFeedbackService, FeedbackService>();


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

            app.UseAuthentication();
            app.UseMvc();
        }

        private void ValidateToken(IConfiguration configuration, IServiceCollection services)
        {
            var audienceconfig = configuration.GetSection("Audience");
            var key = audienceconfig["key"];
            var keyByteArray = Encoding.ASCII.GetBytes(key);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParamters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                ValidateIssuer = true,
                ValidIssuer = audienceconfig["Iss"],

                ValidateAudience = true,
                ValidAudience = audienceconfig["Aud"],

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero

            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParamters;
            });
        }
    }
}

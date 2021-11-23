using Application.Services.UseCases.User;
using Infrastructure.SqlServer.Repositories.User;
using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.User;


namespace projBaladeAPI
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
            
            //REPOS
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IDatabaseManager, DatabaseManager>();
            
            //SERVICES
            
            //USE CASES
            services.AddSingleton<UseCaseGetAllUser>();
            services.AddSingleton<UseCaseCreateUser>();
            services.AddSingleton<UseCaseDeleteUser>();
            services.AddSingleton<UseCaseGetUser>();
            services.AddSingleton<UseCaseUpdateUser>();
            services.AddControllers();
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "My API", Version = "v1"}); });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
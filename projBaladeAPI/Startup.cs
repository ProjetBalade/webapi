using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.UseCases.Dog;
using Infrastructure.SqlServer.Repositories.Dog;
using Infrastructure.SqlServer.System;
using Application.UseCases.Ride;
using Infrastructure.SqlServer.Repositories.Ride;
using Infrastructure.SqlServer.System;
using Application.UseCases.Comment;
using Infrastructure.SqlServer.Repositories.Comment;
using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

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
            
            services.AddSingleton<IDatabaseManager, DatabaseManager>();

            

           
            //Add repos
            services.AddSingleton<ICommentRepository, CommentRepository>();
            services.AddSingleton<IDatabaseManager, DatabaseManager>();

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "WebApi", Version = "v1"}); });

            // Add repos
            services.AddSingleton<IRideRepository, RideRepository>();
            services.AddSingleton<IDogRepository, DogRepository>();
            services.AddSingleton<IDatabaseManager, DatabaseManager>();
            
            // Add use cases
            services.AddSingleton<UseCaseGetAllRide>();
            services.AddSingleton<UseCaseCreateRide>();
            services.AddSingleton<UseCaseUpdateRide>();
            
            services.AddSingleton<UseCaseGetAllDog>();
            services.AddSingleton<UseCaseGetDog>();
            services.AddSingleton<UseCaseCreateDog>();
            services.AddSingleton<UseCaseUpdateDog>();
            services.AddSingleton<UseCaseDeleteDog>();
            
            services.AddSingleton<UseCaseGetAllComments>();
            services.AddSingleton<UseCaseCreateComment>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
            });
            
            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
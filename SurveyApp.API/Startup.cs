using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;

namespace SurveyApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        IWebHostEnvironment Environment { get; }

     
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork>(_ => UnitOfWork.Create(GetDbContextOptions<UnitOfWork>()));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UnitOfWork>();
          
            services.AddControllers();
        }



        static DbContextOptions<T> GetDbContextOptions<T>() where T : UnitOfWork
        {
            return new DbContextOptionsBuilder<T>().UseSqlServer(
                     "server=localhost;database=SurveyApp;integrated security=true",
                    b => b.MigrationsHistoryTable("SurveyApp_Migrations")
                        .MigrationsAssembly(typeof(UnitOfWork).Assembly.FullName))
                .Options;
        }

        class DataContextDesignTimeFactory : IDesignTimeDbContextFactory<UnitOfWork>
        {
            public UnitOfWork CreateDbContext(string[] _) => UnitOfWork.Create(GetDbContextOptions<UnitOfWork>());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SurveyApp.Application.Commands;
using SurveyApp.Application.Repositories;
using SurveyApp.Application.Services;
using SurveyApp.Commands;
using SurveyApp.Commands.Repositories;
using SurveyApp.Commands.Services;
using SurveyApp.Data;
using SurveyApp.Data.Implementations;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.Queries;

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

            #region origin 
            //services.AddScoped<IUnitOfWork>(_ => UnitOfWork.Create(GetDbContextOptions<UnitOfWork>()));

            ////services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UnitOfWork>();

            //services.AddSingleton<IDateTimeService, DateTimeService>();
            //services.AddTransient<ISurveyRepository, SurveyRepository>();
            //services.AddTransient<ISurveyCreateCommand, SurveyCreateCommand>();
            #endregion


            services.AddScoped<IUnitOfWork>(_ => UnitOfWork.Create(GetDbContextOptions<UnitOfWork>()));
            services.AddScoped<IReadDbContext>(_ => ReadDbContext.Create(GetDbContextOptions<ReadDbContext>()));
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<UnitOfWork>();
            services.AddSingleton<IDateTimeService, DateTimeService>();
            services.AddTransient<ISurveyRepository, SurveyRepository>();
            services.AddTransient<IDefineSurveyCommand, DefineSurveyCommand>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAddQuestionToSurveyCommand, AddQuestionToSurveyCommand>();
            services.AddTransient<ISurveyResponseRepository, SurveyResponseRepository>();
            services.AddTransient<IResponseSurveyCommand, ResponseSurveyCommand>();
            services.AddTransient<IOpenSurveyCommand, OpenSurveyCommand>();
            services.AddTransient<ICloseSurveyCommand, CloseSurveyCommand>();
            services.AddTransient<IGetSurveyByIdQuery, GetSurveyByIdQuery>();
            services.AddTransient<IGetOpenSurveysQuery, GetOpenSurveysQuery>();
            services.AddTransient<IGetCloseSurveysQuery, GetCloseSurveysQuery>();
            services.AddTransient<IGetSurveyResponseReportQuery, GetSurveyResponseReportQuery>();
            


            services.AddControllers();
        }



        static DbContextOptions<T> GetDbContextOptions<T>() where T : IdentityDbContext
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
          //  SampleData.Initialize(app.ApplicationServices);
        }
    }
}

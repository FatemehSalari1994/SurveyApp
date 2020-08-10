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
using SurveyApp.Data.Contracts;
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
            services.AddDbContext<SurveyAppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ISurveyDbContext, SurveyAppDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SurveyAppDbContext>();
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
            SampleData.Initialize(app.ApplicationServices);
        }
    }
}

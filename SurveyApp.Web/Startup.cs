using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using SurveyApp.Application.Commands;
using SurveyApp.Application.Repositories;
using SurveyApp.Application.Services;
using SurveyApp.Commands;
using SurveyApp.Commands.Repositories;
using SurveyApp.Commands.Services;
using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.Queries;

namespace SurveyApp.Web
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
            services.AddControllersWithViews();

            services.AddRazorPages().AddRazorRuntimeCompilation();
           
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

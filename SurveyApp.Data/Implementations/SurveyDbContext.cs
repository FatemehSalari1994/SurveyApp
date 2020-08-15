
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using SurveyApp.Data.Contracts;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Proxies;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.Data.Implementations
{

    public class SurveyAppDbContext : IdentityDbContext , ISurveyDbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionResponse> QuestionResponses { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<QuestionSelection> QuestionSelections { get; set; }

        public DbSet<SurveyResponse> SurveyResponses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
           .SelectMany(t => t.GetForeignKeys())
           .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

        }

        public async Task<int> SaveChangesAsync()

            => await base.SaveChangesAsync();



        public SurveyAppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
   
}

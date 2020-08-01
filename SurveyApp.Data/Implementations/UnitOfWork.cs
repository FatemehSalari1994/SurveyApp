
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using SurveyApp.Data.Contracts;
using SurveyApp.Models;
using System;
using System.Collections.Generic;

using System.Text;

namespace SurveyApp.Data.Implementations
{
    public class UnitOfWork : IdentityDbContext, IUnitOfWork
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionResponse> QuestionResponses { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<QuestionSelection> QuestionSelections { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }

        UnitOfWork(DbContextOptions<UnitOfWork> options, string defaultSchema = null) : this((DbContextOptions)options, defaultSchema)
        {
        }
        UnitOfWork(DbContextOptions options, string defaultSchema = null) : base(options)
        {
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var tracker = base.ChangeTracker;
                tracker.AutoDetectChangesEnabled = true;
                tracker.LazyLoadingEnabled = true;
                tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                return tracker;
            }
        }
      

        [Obsolete]
        public void SetModified(object entity, string propertyName, string referencePropertyName = null)
        {
            if (referencePropertyName != null)
                entity = Entry(entity).Reference(referencePropertyName).TargetEntry.Entity;

            Entry(entity).Property(propertyName).IsModified = true;
        }

        public static UnitOfWork Create(DbContextOptions<UnitOfWork> options) => Create(options, null);
        public static UnitOfWork Create(DbContextOptions<UnitOfWork> options, string defaultSchema) =>
            new UnitOfWork(options, defaultSchema);
        public new static UnitOfWork Create(DbContextOptions options, string defaultSchema = null) =>
            new UnitOfWork(options, defaultSchema);
    }
}

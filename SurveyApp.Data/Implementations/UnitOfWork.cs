
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

namespace SurveyApp.Data.Implementations
{
    #region origin 
    //public class UnitOfWork : IdentityDbContext, IUnitOfWork
    //{
    //    public System.Data.Entity.DbSet<Question> Questions { get; protected set; }

    //    public System.Data.Entity.DbSet<QuestionResponse> QuestionResponses { get; protected set; }

    //    public System.Data.Entity.DbSet<Survey> Surveys { get; protected set; }

    //    public System.Data.Entity.DbSet<QuestionSelection> QuestionSelections { get; protected set; }

    //    public System.Data.Entity.DbSet<SurveyResponse> SurveyResponses { get; protected set; }


    //    UnitOfWork(DbContextOptions<UnitOfWork> options, string defaultSchema = null) : this((DbContextOptions)options, defaultSchema)
    //    {
    //    }
    //    UnitOfWork(DbContextOptions options, string defaultSchema = null) : base(options)
    //    {
    //    }

    //    public override ChangeTracker ChangeTracker
    //    {
    //        get
    //        {
    //            var tracker = base.ChangeTracker;
    //            tracker.AutoDetectChangesEnabled = true;
    //            tracker.LazyLoadingEnabled = true;
    //            tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    //            return tracker;
    //        }
    //    }



    //    [Obsolete]
    //    public void SetModified(object entity, string propertyName, string referencePropertyName = null)
    //    {
    //        if (referencePropertyName != null)
    //            entity = Entry(entity).Reference(referencePropertyName).TargetEntry.Entity;

    //        Entry(entity).Property(propertyName).IsModified = true;
    //    }

    //    public static UnitOfWork Create(DbContextOptions<UnitOfWork> options) => Create(options, null);
    //    public static UnitOfWork Create(DbContextOptions<UnitOfWork> options, string defaultSchema) =>
    //        new UnitOfWork(options, defaultSchema);
    //    public new static UnitOfWork Create(DbContextOptions options, string defaultSchema = null) =>
    //        new UnitOfWork(options, defaultSchema);
    //}
    #endregion

    public interface IReadDbContext : IDisposable
    {

        DbSet<Question> Questions { get;  }

        DbSet<QuestionResponse> QuestionResponses { get;  }

        DbSet<Survey> Surveys { get;  }

        DbSet<QuestionSelection> QuestionSelections { get;  }

        DbSet<SurveyResponse> SurveyResponses { get;  }





    }

    public interface IUnitOfWork : IReadDbContext
    {
        int SaveChanges();

    }
    public class ReadDbContext : IdentityDbContext, IReadDbContext
    {
        readonly string _defaultSchema;

  

        protected ReadDbContext(DbContextOptions options, string defaultSchema = null) : base(options)
        {
            _defaultSchema = defaultSchema;
        }
        ReadDbContext(DbContextOptions<ReadDbContext> options, string defaultSchema = null) : base(options)
        {
            _defaultSchema = defaultSchema;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            
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

        public DbSet<Question> Questions { get; protected set; }

        public DbSet<QuestionResponse> QuestionResponses { get; protected set; }

        public DbSet<Survey> Surveys { get; protected set; }

        public DbSet<QuestionSelection> QuestionSelections { get; protected set; }

        public DbSet<SurveyResponse> SurveyResponses { get; protected set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
           .SelectMany(t => t.GetForeignKeys())
           .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);

        }

        public static ReadDbContext Create(DbContextOptions<ReadDbContext> options) => Create(options, null);
        public static ReadDbContext Create(DbContextOptions<ReadDbContext> options, string defaultSchema) =>
            new ReadDbContext(options, defaultSchema);
        public static ReadDbContext Create(DbContextOptions options, string defaultSchema = null) =>
            new ReadDbContext(options, defaultSchema);
    }

    public class UnitOfWork : ReadDbContext, IUnitOfWork
    {
        UnitOfWork(DbContextOptions<UnitOfWork> options, string defaultSchema = null) : this((DbContextOptions)options, defaultSchema)
        {
        }
        UnitOfWork(DbContextOptions options, string defaultSchema = null) : base(options, defaultSchema)
        {
        }

        public override ChangeTracker ChangeTracker
        {
            get
            {
                var tracker = base.ChangeTracker;
                tracker.AutoDetectChangesEnabled = true;
                tracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
                tracker.LazyLoadingEnabled = true;
                return tracker;
            }
        }

        public static UnitOfWork Create(DbContextOptions<UnitOfWork> options) => Create(options, null);
        public static UnitOfWork Create(DbContextOptions<UnitOfWork> options, string defaultSchema) =>
            new UnitOfWork(options, defaultSchema);
        public new static UnitOfWork Create(DbContextOptions options, string defaultSchema = null) =>
            new UnitOfWork(options, defaultSchema);
    }
}

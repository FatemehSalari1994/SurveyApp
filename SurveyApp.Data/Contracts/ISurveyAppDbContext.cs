using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveyApp.Models;
using System;

namespace SurveyApp.Data.Contracts
{
    public interface ISurveyDbContext
    {

        DbSet<Question> Questions { get; }
        DbSet<QuestionResponse> QuestionResponses { get; }
        DbSet<Survey> Surveys { get; }
        DbSet<QuestionSelection> QuestionSelections { get; }
        DbSet<SurveyResponse> SurveyResponses { get; }

        int SaveChanges();
    }
}

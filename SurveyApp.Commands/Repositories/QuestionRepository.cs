using SurveyApp.Application.Repositories;
using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Commands.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        ISurveyDbContext _surveyDbContext;
        public QuestionRepository(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(Question question)
        {
            _surveyDbContext.Questions.Add(question);
            _surveyDbContext.SaveChanges();
        }
    }
}

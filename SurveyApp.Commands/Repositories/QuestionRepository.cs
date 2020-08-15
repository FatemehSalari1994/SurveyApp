using SurveyApp.Application.Repositories;
using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Commands.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        ISurveyDbContext _surveyDbContext;
        public QuestionRepository(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public async Task Add(Question question)
        {
            await _surveyDbContext.Questions.AddAsync(question);
            await _surveyDbContext.SaveChangesAsync();        
        }
    }
}

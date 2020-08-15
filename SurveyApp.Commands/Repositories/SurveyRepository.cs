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
    public class SurveyRepository : ISurveyRepository
    {
        ISurveyDbContext _surveyDbContext;
        public SurveyRepository(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public async Task Add(Survey survey)
        {
            await _surveyDbContext.Surveys.AddAsync(survey);
            await _surveyDbContext.SaveChangesAsync();
        }

        public async Task<Survey> FindById(int id)
            => await _surveyDbContext.Surveys.FindAsync(id);

        public async Task Update(Survey survey)
             => await _surveyDbContext.SaveChangesAsync();
        
    }
}

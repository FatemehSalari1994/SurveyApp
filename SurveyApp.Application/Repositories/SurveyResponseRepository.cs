using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Repositories
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        ISurveyDbContext _surveyDbContext;
        public SurveyResponseRepository(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public async Task Add(SurveyResponse surveyResponse)
        {
            _surveyDbContext.SurveyResponses.Add(surveyResponse);
            _surveyDbContext.SaveChanges();
        }
    }
}

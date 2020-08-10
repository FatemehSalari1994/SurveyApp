using SurveyApp.Application.Repositories;
using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Commands.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        ISurveyDbContext _surveyDbContext;
        public SurveyRepository(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public void Add(Survey survey)
        {
            _surveyDbContext.Surveys.Add(survey);
            _surveyDbContext.SaveChanges();
        }

        public Survey FindById(int id)
            => _surveyDbContext.Surveys.Find(id);

        public void Update(Survey survey)
        {
            _surveyDbContext.Surveys.Update(survey);
            _surveyDbContext.SaveChanges();
        }
    }
}

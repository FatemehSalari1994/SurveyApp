using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyApp.Queries.Queries
{
    public class GetCloseSurveysQuery : IGetCloseSurveysQuery
    {
        ISurveyDbContext _surveyDbContext;
        public GetCloseSurveysQuery(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public IList<SurveyDto> Execute()
            => _surveyDbContext.Surveys.Where(s => s.IsOpen == false)
                                 .Select(_ => new SurveyDto
                                 {
                                     Id = _.Id,
                                     DefineDateTime = _.DefineDateTime,
                                     QuestionCount = _.Questions.Count(),
                                     ResponseCount = _.SurveyResponses.Count(),
                                     Title = _.Title
                                 }).ToList();
    }
}

using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Queries.Queries
{
    public class GetSurveyResponseReportQuery : IGetSurveyResponseReportQuery
    {
        ISurveyDbContext _surveyDbContext;
        public GetSurveyResponseReportQuery(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public async Task<SurveyReportDto> Execute(int id)
        {
            var survey =await  _surveyDbContext.Surveys.FindAsync(id);
            var k = survey.Questions.Select(_ => new QuestionResponseReport
            {
                QuestionTitle = _.Title,
                Responses = _.QuestionSelections.ToDictionary(x => x.Title, x => x.QuestionResponses.Count())
            });
            return new SurveyReportDto
            {
                Title=survey.Title,
                IsOpen=survey.IsOpen,
                DefineDateTime=survey.DefineDateTime,
                CoordinatorId=survey.CoordinatorId,
                ResponseCount=survey.SurveyResponses.Count(),
                QuestionResponseReports=survey.Questions.Select(_=>new QuestionResponseReport
                {
                    QuestionTitle=_.Title,
                    Responses=_.QuestionSelections.ToDictionary(x=>x.Title,x=>x.QuestionResponses.Count())
                }).ToList()
            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
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
    public class GetOpenSurveysQuery : IGetOpenSurveysQuery
    {
        ISurveyDbContext _surveyDbContext;
        public GetOpenSurveysQuery(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public async Task<IList<SurveyDto>> Execute()
            => await _surveyDbContext.Surveys.Where(s => s.IsOpen == true)
                                 .Select(_ => new SurveyDto
                                  {
                                     Id=_.Id,
                                     DefineDateTime=_.DefineDateTime,
                                     QuestionCount=_.Questions.Count(),
                                     ResponseCount=_.SurveyResponses.Count(),
                                     Title=_.Title
                                  }).ToListAsync();
        
    }
}

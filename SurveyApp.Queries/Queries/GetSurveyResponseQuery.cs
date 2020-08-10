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
    public class GetSurveyResponseQuery : IGetSurveyResponseQuery
    {
        ISurveyDbContext _surveyDbContext;
        public GetSurveyResponseQuery(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }
        public SurveyResponseDto Execute(int id)
        {
            var surveyResponse = _surveyDbContext.SurveyResponses.Find(id);
            return new SurveyResponseDto
            {
                RespondentId=surveyResponse.RespondentId,
                ResponseDateTime=surveyResponse.ResponseDateTime,
                QuestionResponses= surveyResponse.QuestionResponses.Select(_=> new QuestionResponseDto
                {
                    QuestionTitle=_.Question.Title,
                    ResponseTitle=_.QuestionSelection.Title
                }).ToList()
            };
        }
    }
}

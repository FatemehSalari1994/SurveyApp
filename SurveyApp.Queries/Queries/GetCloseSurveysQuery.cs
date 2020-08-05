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
        IUnitOfWork _unitOfWork;
        public GetCloseSurveysQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IList<SurveyDto> Execute()
            => _unitOfWork.Surveys.Where(s => s.IsOpen == false)
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

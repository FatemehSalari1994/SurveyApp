using SurveyApp.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Queries.Contracts
{
    public interface IGetCloseSurveysQuery
    {
        IList<SurveyDto> Execute();
    }
}

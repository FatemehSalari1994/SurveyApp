using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.Dtos;
using SurveyApp.Queries.ViewModels;

namespace SurveyApp.API.Controllers
{
    [Route("api/survey")]
    [ApiController]
    public class SurveyQueriesController : ControllerBase
    {
        IGetSurveyByIdQuery _getSurveyByIdQuery;
        IGetOpenSurveysQuery _getOpenSurveysQuery;
        IGetCloseSurveysQuery _getCloseSurveysQuery;
        IGetSurveyResponseReportQuery _getSurveyResponseReportQuery;
        public SurveyQueriesController(IGetSurveyByIdQuery getSurveyByIdQuery,
                                       IGetOpenSurveysQuery getOpenSurveysQuery,
                                       IGetCloseSurveysQuery getCloseSurveysQuery,
                                       IGetSurveyResponseReportQuery getSurveyResponseReportQuery)
        {
            _getSurveyByIdQuery = getSurveyByIdQuery;
            _getOpenSurveysQuery = getOpenSurveysQuery;
            _getCloseSurveysQuery = getCloseSurveysQuery;
            _getSurveyResponseReportQuery = getSurveyResponseReportQuery;
        }

        [HttpGet("{id}")]
        public async Task<SurveyWithQuestionsDto> GetById([FromRoute]int id)
            => await  _getSurveyByIdQuery.Execute(id);

        [HttpGet("open")]
        public async Task<IList<SurveyDto>> GetOpenSurveys()
             => await  _getOpenSurveysQuery.Execute();

        [HttpGet("close")]
        public async Task<IList<SurveyDto>> GetCloseSurveys()
           => await _getCloseSurveysQuery.Execute();

        [HttpGet("{id}/report")]
        public async Task<SurveyReportDto> Report([FromRoute] int id)
         => await _getSurveyResponseReportQuery.Execute(id);
    }
}
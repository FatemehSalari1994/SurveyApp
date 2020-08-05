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
        public SurveyQueriesController(IGetSurveyByIdQuery getSurveyByIdQuery,
                                       IGetOpenSurveysQuery getOpenSurveysQuery,
                                       IGetCloseSurveysQuery getCloseSurveysQuery)
        {
            _getSurveyByIdQuery = getSurveyByIdQuery;
            _getOpenSurveysQuery = getOpenSurveysQuery;
            _getCloseSurveysQuery = getCloseSurveysQuery;
        }

        [HttpGet("{id}")]
        public async Task<SurveyWithQuestionsDto> GetById([FromRoute]int id)
            => await Task.Run(() => _getSurveyByIdQuery.Execute(id));

        [HttpGet("{id}")]
        public async Task<SurveyWithQuestionsDto> GetById([FromRoute]int id)
          => await Task.Run(() => _getSurveyByIdQuery.Execute(id));

        //get open survey
        [HttpGet("open")]
        public async Task<IList<SurveyDto>> GetOpenSurveys()
             => await Task.Run(() => _getOpenSurveysQuery.Execute());

        [HttpGet("close")]
        public async Task<IList<SurveyDto>> GetCloseSurveys()
           => await Task.Run(() => _getCloseSurveysQuery.Execute());
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Queries.Dtos;

namespace SurveyApp.API.Controllers
{
    [Route("api/survey-response")]
    [ApiController]
    public class SurveyResponseQueriesController : ControllerBase
    {
        IGetSurveyResponseQuery _getSurveyResponseQuery;
        public SurveyResponseQueriesController( getSurveyResponseQuery)
        {
            _getSurveyResponseQuery = getSurveyResponseQuery;
        }

        [HttpGet("{id}")]
        public async Task<SurveyResponseDto> Get([FromRoute] int id)
        
            => await Task.Run(() =>
               {
                   _getSurveyResponseQuery.Execute(id, surveyResponseViewModel);
               });
        
    }
}
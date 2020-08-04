using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.ViewModels;

namespace SurveyApp.API.Controllers
{
    [Route("api/survey")]
    [ApiController]
    public class SurveyQueriesController : ControllerBase
    {
        IGetSurveyByIdQuery _getSurveyByIdQuery;
        public SurveyQueriesController(IGetSurveyByIdQuery getSurveyByIdQuery)
        {
            _getSurveyByIdQuery = getSurveyByIdQuery;
        }

        [HttpGet("{id}")]
        public async Task<SurveyDto> Get([FromRoute]int id)
            => await Task.Run(() => _getSurveyByIdQuery.Execute(id)); 

        //get open surveys
        //get close surveys
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.ViewModels;

namespace SurveyApp.API.Controllers
{
    [Route("api/survey-response")]
    [ApiController]
    public class SurveyResponseCommandsController : ControllerBase
    {
        IResponseSurveyCommand _responseSurveyCommand;
        public SurveyResponseCommandsController(IResponseSurveyCommand responseSurveyCommand)
        {
            _responseSurveyCommand = responseSurveyCommand;
        }
        [HttpPost("{id}")]
        public async Task Response([FromRoute] int id,
                                   [FromBody] SurveyResponseViewModel surveyResponseViewModel)
            => await _responseSurveyCommand.Execute(id,surveyResponseViewModel);

        
    }
}
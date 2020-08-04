using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.Dtos;
using SurveyApp.Application.Commands.ViewModels;

namespace SurveyApp.API.Controllers
{
    [Route("api/survey")]
    [ApiController]
    public class SurveyCommandsController : ControllerBase
    {
        IDefineSurveyCommand _defineSurveyCommand;
        IAddQuestionToSurveyCommand _addQuestionToSurveyCommand;
        public SurveyCommandsController(IDefineSurveyCommand defineSurveyCommand,
                                        IAddQuestionToSurveyCommand addQuestionToSurveyCommand)
        {
            _defineSurveyCommand = defineSurveyCommand;
            _addQuestionToSurveyCommand = addQuestionToSurveyCommand;
        }

        [HttpPost]
        public async Task Define([FromBody]SurveyViewModel surveyViewModel)
            => await Task.Run(() =>
            {
                _defineSurveyCommand.Execute(surveyViewModel);
            });

        [HttpPost("{id}/question")]
        public async Task AddQuestion([FromRoute]int id, QuestionViewModel questionDto)
            => await Task.Run(() =>
            {
                _addQuestionToSurveyCommand.Execute(id, questionDto);
            });

        //open survey
        //close survey
            
    }
}
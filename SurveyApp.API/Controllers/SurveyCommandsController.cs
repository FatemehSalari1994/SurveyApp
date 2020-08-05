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
        IOpenSurveyCommand _openSurveyCommand;
        ICloseSurveyCommand _closeSurveyCommand;
        public SurveyCommandsController(IDefineSurveyCommand defineSurveyCommand,
                                        IAddQuestionToSurveyCommand addQuestionToSurveyCommand,
                                        IOpenSurveyCommand openSurveyCommand,
                                        ICloseSurveyCommand closeSurveyCommand)
        {
            _defineSurveyCommand = defineSurveyCommand;
            _addQuestionToSurveyCommand = addQuestionToSurveyCommand;
            _openSurveyCommand = openSurveyCommand;
            _closeSurveyCommand = closeSurveyCommand;
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

        
        [HttpPost("{id}/open")]
        public async Task Open([FromRoute]int id)
            => await Task.Run(() =>
            {
                _openSurveyCommand.Execute(id);
            });

       
        [HttpPost("{id}/close")]
        public async Task Close([FromRoute]int id)
            => await Task.Run(() =>
            {
                _closeSurveyCommand.Execute(id);
            });

    }
}
using SurveyApp.Application.Commands;
using SurveyApp.Application.Repositories;
using SurveyApp.Commands.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Commands
{
    public class OpenSurveyCommand : IOpenSurveyCommand
    {
        ISurveyRepository _surveyRepository;
        public OpenSurveyCommand(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }
        public async Task Execute(int id)
        {
            var survey = _surveyRepository.FindById(id).Result;

            if (survey==null)
                throw new SurveyNotFoundException();

            survey.IsOpen = true;
            
            await _surveyRepository.Update(survey);
        }
    }
}

using SurveyApp.Application.Commands;
using SurveyApp.Application.Repositories;
using SurveyApp.Commands.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Commands
{
    public class OpenSurveyCommand : IOpenSurveyCommand
    {
        ISurveyRepository _surveyRepository;
        public OpenSurveyCommand(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }
        public void Execute(int id)
        {
            var survey = _surveyRepository.FindById(id);

            if (survey==null)
                throw new SurveyNotFoundException();

            survey.IsOpen = true;
            _surveyRepository.Update(survey);
        }
    }
}

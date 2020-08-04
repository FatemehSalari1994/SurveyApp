using SurveyApp.Application.Commands.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Commands
{
    public interface IDefineSurveyCommand
    {
        void Execute(SurveyViewModel surveyViewModel);
    }
}

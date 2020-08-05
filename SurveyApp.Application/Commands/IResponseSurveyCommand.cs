using SurveyApp.Application.Commands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Commands
{
    public interface IResponseSurveyCommand
    {
        void Execute(int id,SurveyResponseViewModel surveyResponseViewModel);
    }
}

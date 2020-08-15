
using SurveyApp.Application.Commands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Commands
{
    public interface IDefineSurveyCommand
    {
        Task Execute(SurveyViewModel surveyViewModel);
    }
}

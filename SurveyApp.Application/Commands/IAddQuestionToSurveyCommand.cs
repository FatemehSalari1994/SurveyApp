using SurveyApp.Application.Commands.Dtos;
using SurveyApp.Application.Commands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Commands
{
    public interface IAddQuestionToSurveyCommand
    {
        void Execute(int id,QuestionViewModel questionViewModel);
    }
}

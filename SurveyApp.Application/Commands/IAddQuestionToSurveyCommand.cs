using SurveyApp.Application.Commands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Commands
{
    public interface IAddQuestionToSurveyCommand
    {
        Task Execute(int id,QuestionViewModel questionViewModel);
    }
}

using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.ViewModels;
using SurveyApp.Application.Repositories;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyApp.Commands
{
    public class AddQuestionToSurveyCommand : IAddQuestionToSurveyCommand
    {
        IQuestionRepository _questionRepository;
        public AddQuestionToSurveyCommand(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public void Execute(int id, QuestionViewModel questionViewModel)
        {
            var question = new Question
            {
                Title = questionViewModel.Title,
                SurveyId = id,
                QuestionSelections = questionViewModel.SelectionsTitles
                                                .Select(qs => new QuestionSelection
                                                {
                                                    Title = qs
                                                })
                                                .ToList()
            };

            _questionRepository.Add(question);

        }
    }
}

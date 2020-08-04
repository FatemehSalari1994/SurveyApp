using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.ViewModels;
using SurveyApp.Application.Repositories;
using SurveyApp.Application.Services;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyApp.Commands
{
    public class ResponseSurveyCommand : IResponseSurveyCommand
    {
        ISurveyResponseRepository _surveyResponseRepository;
        IDateTimeService _dateTimeService;
        public ResponseSurveyCommand(ISurveyResponseRepository surveyResponseRepository,
                                     IDateTimeService dateTimeService)
        {
            _surveyResponseRepository = surveyResponseRepository;
            _dateTimeService = dateTimeService;
        }
        public void Execute(SurveyResponseViewModel surveyResponseViewModel)
        {
            var surveyResponse = new SurveyResponse
            {
                RespondentId = surveyResponseViewModel.RespondentId,
                ResponseDateTime = _dateTimeService.Today,
                QuestionResponses = surveyResponseViewModel.QuestionsResponseIds.Select(qs => new QuestionResponse
                {
                    QuestionSelectionId = qs
                }).ToList()
            };
            _surveyResponseRepository.Add(surveyResponse);
        }
    }
}

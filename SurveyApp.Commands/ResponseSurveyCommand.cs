using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.ViewModels;
using SurveyApp.Application.Repositories;
using SurveyApp.Application.Services;
using SurveyApp.Commands.Exceptions;
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
        ISurveyRepository _surveyRepository;
        IDateTimeService _dateTimeService;

        public ResponseSurveyCommand(ISurveyResponseRepository surveyResponseRepository,
                                     ISurveyRepository surveyRepository,
                                     IDateTimeService dateTimeService)
        {
            _surveyResponseRepository = surveyResponseRepository;
            _dateTimeService = dateTimeService;
            _surveyRepository = surveyRepository;
        }

        public void Execute(int id,SurveyResponseViewModel surveyResponseViewModel)
        {
            var survey = _surveyRepository.FindById(id);
            if (survey == null)
                throw new SurveyNotFoundException();

            if (!survey.IsOpen)
                throw new ResponseCloseSurveyException();

            var hasQuestionWithoutResponse = !survey.Questions.Select(x => x.Id)
                                    .All(surveyResponseViewModel.QuestionsResponses.Select(y => y.QuestionId).Contains);
            if (hasQuestionWithoutResponse)
                throw new QuestionWithoutResponseExeption();

            //if (survey.SurveyResponses.Any(x => x.RespondentId == surveyResponseViewModel.RespondentId))
            //    throw new SameRespondentException();

            var surveyResponse = new SurveyResponse
            {
                RespondentId = surveyResponseViewModel.RespondentId,
                ResponseDateTime = _dateTimeService.Today,
                SurveyId=id,
                QuestionResponses = surveyResponseViewModel.QuestionsResponses.Select(qs => new QuestionResponse
                {
                    QuestionSelectionId = qs.ResponseId,
                    QuestionId=qs.QuestionId

                }).ToList()
            };

            _surveyResponseRepository.Add(surveyResponse);
        }
    }
}

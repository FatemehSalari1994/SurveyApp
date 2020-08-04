using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.Dtos;
using SurveyApp.Application.Repositories;
using SurveyApp.Application.Services;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Commands
{
    public class DefineSurveyCommand : IDefineSurveyCommand
    {
        ISurveyRepository _surveyRepository;
        IDateTimeService _dateTime;
        public DefineSurveyCommand(ISurveyRepository surveyRepository,
                                   IDateTimeService dateTime)
        {
            _surveyRepository = surveyRepository;
            _dateTime = dateTime;
        }
        public void Execute(SurveyViewModel surveyViewModel)
        {
            var survey = new Survey
            {
                Title=surveyViewModel.Title,
                IsOpen=false,
                CreateDateTime=_dateTime.Today,
                CoordinatorId=surveyViewModel.CoordinatorId
            };

            _surveyRepository.Add(survey);
        }
    }
}

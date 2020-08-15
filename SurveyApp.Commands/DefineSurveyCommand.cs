using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.ViewModels;
using SurveyApp.Application.Repositories;
using SurveyApp.Application.Services;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        public async Task Execute(SurveyViewModel surveyViewModel)
        {
            var survey = new Survey
            {
                Title=surveyViewModel.Title,
                IsOpen=false,
                DefineDateTime=_dateTime.Today,
                CoordinatorId=surveyViewModel.CoordinatorId
            };

             await _surveyRepository.Add(survey);
   
        }
    }
}

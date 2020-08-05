﻿using SurveyApp.Data.Implementations;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SurveyApp.Queries.Queries
{
    public class GetSurveyResponseReportQuery : IGetSurveyResponseReportQuery
    {
        IUnitOfWork _unitOfWork;
        public GetSurveyResponseReportQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public SurveyReportDto Execute(int id)
        {
            var survey = _unitOfWork.Surveys.Find(id);
            return new SurveyReportDto
            {
                Title=survey.Title,
                IsOpen=survey.IsOpen,
                DefineDateTime=survey.DefineDateTime,
                CoordinatorId=survey.CoordinatorId,
                ResponseCount=survey.SurveyResponses.Count(),
                QuestionResponseReports=survey.Questions.Select(_=>new QuestionResponseReport
                {
                    QuestionTitle=_.Title,
                    Responses=_.QuestionSelections.ToDictionary(x=>x.Title,x=>x.QuestionResponses.Count())
                }).ToList()
            };
        }
    }
}

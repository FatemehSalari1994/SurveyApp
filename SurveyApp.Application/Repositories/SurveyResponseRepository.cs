using SurveyApp.Data.Implementations;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Repositories
{
    public class SurveyResponseRepository : ISurveyResponseRepository
    {
        IUnitOfWork _unitOfWork;
        public SurveyResponseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(SurveyResponse surveyResponse)
        {
            _unitOfWork.SurveyResponses.Add(surveyResponse);
            _unitOfWork.SaveChanges();
        }
    }
}

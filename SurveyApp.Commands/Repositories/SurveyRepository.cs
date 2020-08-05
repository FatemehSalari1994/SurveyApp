using SurveyApp.Application.Repositories;
using SurveyApp.Data.Implementations;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Commands.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        IUnitOfWork _unitOfWork;
        public SurveyRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Survey survey)
        {
            _unitOfWork.Surveys.Add(survey);
            _unitOfWork.SaveChanges();
        }

        public Survey FindById(int id)
            => _unitOfWork.Surveys.Find(id);

        public void Update(Survey survey)
        {
            _unitOfWork.Surveys.Update(survey);
            _unitOfWork.SaveChanges();
        }
    }
}

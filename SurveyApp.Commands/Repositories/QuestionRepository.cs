using SurveyApp.Application.Repositories;
using SurveyApp.Data.Implementations;
using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Commands.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        IUnitOfWork _unitOfWork;
        public QuestionRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Question question)
        {
            _unitOfWork.Questions.Add(question);
            _unitOfWork.SaveChanges();
        }
    }
}

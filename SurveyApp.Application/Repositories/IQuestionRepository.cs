using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Repositories
{
    public interface IQuestionRepository
    {
        void Add(Question question);
    }
}

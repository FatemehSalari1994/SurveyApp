using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Repositories
{
    public interface IQuestionRepository
    {
        Task Add(Question question);
    }
}

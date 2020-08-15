using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Repositories
{
    public interface ISurveyRepository
    {
        Task Add(Survey survey);
        Task<Survey> FindById(int id);
        Task Update(Survey survey);
    }
}

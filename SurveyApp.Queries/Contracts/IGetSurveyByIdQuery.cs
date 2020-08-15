using SurveyApp.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Queries.Contracts
{
    public interface IGetSurveyByIdQuery
    {
        Task<SurveyWithQuestionsDto> Execute(int id);
    }
}

using SurveyApp.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Queries.Contracts
{
    public interface IGetSurveyByIdQuery
    {
        SurveyDto Execute(int id);
    }
}

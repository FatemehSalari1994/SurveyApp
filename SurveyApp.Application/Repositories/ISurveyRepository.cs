using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Repositories
{
    public interface ISurveyRepository
    {
        void Add(Survey survey);
        Survey FindById(int id);
        void Update(Survey survey);
    }
}

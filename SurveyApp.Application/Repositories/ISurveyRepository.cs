using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Repositories
{
    public interface ISurveyRepository
    {
        void Add(Survey survey);
    }
}

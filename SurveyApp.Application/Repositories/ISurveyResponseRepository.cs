using SurveyApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Repositories
{
    public interface ISurveyResponseRepository
    {
        void Add(SurveyResponse surveyResponse);
    }
}

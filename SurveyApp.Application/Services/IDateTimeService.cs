using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Services
{
    public interface IDateTimeService
    {
        DateTime Today { get; }
    }
}

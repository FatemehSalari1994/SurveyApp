using SurveyApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Commands.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Today => DateTime.Now;
    }
}

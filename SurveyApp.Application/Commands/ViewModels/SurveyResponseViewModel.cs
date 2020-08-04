using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Commands.ViewModels
{
    public class SurveyResponseViewModel
    {
        public string RespondentId { get; set; }
        public List<int> QuestionsResponseIds { get; set; }
    }

}

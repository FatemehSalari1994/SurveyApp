using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Commands.ViewModels
{
    public class SurveyResponseViewModel
    {
        public string RespondentId { get; set; }
        public List<QuestionResponseViewModel> QuestionsResponses { get; set; }
    }

    public class QuestionResponseViewModel
    {
        public int QuestionId { get; set; }
        public int ResponseId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyApp.Application.Commands.ViewModels
{
    public class SurveyResponseViewModel
    {
        [Display(Name = "جواب دهنده")]
        public string RespondentId { get; set; }
        [Display(Name = "جواب های سوال")]
        public List<QuestionResponseViewModel> QuestionsResponses { get; set; }
    }

    public class QuestionResponseViewModel
    {
        [Display(Name = "سوال")]
        public int QuestionId { get; set; }
        [Display(Name = "جواب")]
        public int ResponseId { get; set; }
    }
}

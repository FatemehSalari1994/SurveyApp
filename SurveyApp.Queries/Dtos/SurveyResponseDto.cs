using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyApp.Queries.Dtos
{
    public class SurveyResponseDto
    {
        public string RespondentId { get; set; }
        [Display(Name = "زمان پاسخدهی")]
        public DateTime ResponseDateTime { get; set; }
        public IList<QuestionResponseDto> QuestionResponses { get; set; }
    }

    public class QuestionResponseDto
    {
        [Display(Name = "عنوان سوال")]
        public string QuestionTitle { get; set; }
        [Display(Name = "عنوان جواب")]
        public string ResponseTitle { get; set; }
    }
}

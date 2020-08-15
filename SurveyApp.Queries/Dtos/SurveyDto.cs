using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyApp.Queries.Dtos
{
    public class SurveyDto
    {
        public int Id { get; set; }
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "تعداد سوال")]
        public int QuestionCount { get; set; }
        [Display(Name = "تعداد پاسخ")]
        public int ResponseCount { get; set; }
        [Display(Name = "زمان طراحی")]
        public DateTime DefineDateTime { get; set; }
    }
}

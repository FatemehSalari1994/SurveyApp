using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyApp.Application.Commands.ViewModels
{
    public class QuestionViewModel
    {
        [Display(Name ="عنوان")]
        public string Title { get; set; }
        [Display(Name = "انتخاب ها")]
        public string[] SelectionsTitles { get; set; }
    }
}

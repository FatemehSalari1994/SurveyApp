using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyApp.Application.Commands.ViewModels
{
    public class SurveyViewModel
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "طراح")]
        public string CoordinatorId { get; set; }
    }
}

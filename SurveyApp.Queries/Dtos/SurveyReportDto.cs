using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyApp.Queries.Dtos
{
    public class SurveyReportDto
    {
        [Display(Name = "عنوان")]
        public string Title { get; set; }
        [Display(Name = "طراح")]
        public string CoordinatorId { get; set; }
        [Display(Name = "زمان طراحی")]
        public DateTime DefineDateTime { get; set; }
        [Display(Name = "باز برای پاسخدهی؟")]
        public bool IsOpen { get; set; }
        [Display(Name = "تعداد جواب")]
        public int ResponseCount { get; set; }

        public IList<QuestionResponseReport> QuestionResponseReports { get; set; }
    }

    public class QuestionResponseReport
    {
        [Display(Name = "عنوان سوال")]
        public string QuestionTitle { get; set; }
        [Display(Name = "جواب ها")]
        public Dictionary<string,int> Responses { get; set; }
    }
}

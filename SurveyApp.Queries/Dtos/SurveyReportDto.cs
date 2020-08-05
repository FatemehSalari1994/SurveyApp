using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Queries.Dtos
{
    public class SurveyReportDto
    {
        public string Title { get; set; }
        public string CoordinatorId { get; set; }
        public DateTime DefineDateTime { get; set; }
        public bool IsOpen { get; set; }

        public int ResponseCount { get; set; }

        public IList<QuestionResponseReport> QuestionResponseReports { get; set; }
    }

    public class QuestionResponseReport
    {
        public string QuestionTitle { get; set; }
        public Dictionary<string,int> Responses { get; set; }
    }
}

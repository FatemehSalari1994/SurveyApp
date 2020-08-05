using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Queries.Dtos
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionCount { get; set; }
        public int ResponseCount { get; set; }
        public DateTime DefineDateTime { get; set; }
    }
}

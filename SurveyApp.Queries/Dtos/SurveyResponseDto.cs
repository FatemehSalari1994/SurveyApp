using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Queries.Dtos
{
    public class SurveyResponseDto
    {
        public string RespondentId { get; set; }
        public DateTime ResponseDateTime { get; set; }
        public IList<QuestionResponseDto> QuestionResponses { get; set; }
    }

    public class QuestionResponseDto
    {
        public string QuestionTitle { get; set; }
        public string ResponseTitle { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SurveyApp.Models
{
    public class SurveyResponse
    {
        [Key]
        public int Id { get; set; }
        public string RespondentId { get; set; }
        public DateTime ResponseDateTime { get; set; }        
        public ICollection<QuestionResponse> QuestionResponses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SurveyApp.Models
{
    public class SurveyResponse
    {
        public SurveyResponse()
        {
            QuestionResponses = new List<QuestionResponse>();
        }

        [Key]
        public int Id { get; set; }
        public string RespondentId { get; set; }
        public DateTime ResponseDateTime { get; set; }        
        public virtual ICollection<QuestionResponse> QuestionResponses { get; set; }

        public int SurveyId { get; set; }
        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class Question
    {
        public Question()
        {
            QuestionSelections = new List<QuestionSelection>();
            QuestionResponses = new List<QuestionResponse>();
        }
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }      
        public string Title { get; set; }
        public virtual ICollection<QuestionSelection> QuestionSelections { get; set; }
        public virtual ICollection<QuestionResponse> QuestionResponses { get; set; }

        [ForeignKey("SurveyId")]
        public virtual Survey Survey { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class QuestionSelection
    {
        public QuestionSelection()
        {
            QuestionResponses = new List<QuestionResponse>();
        }
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
        public virtual ICollection<QuestionResponse> QuestionResponses { get; set; }
    }
}
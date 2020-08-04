using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class QuestionResponse
    { 
        [Key]
        public int Id { get; set; }
        public int SurveyResponseId { get; set; }     
        public int QuestionSelectionId { get; set; }
        [ForeignKey("SurveyResponseId")]
        public virtual SurveyResponse SurveyResponse { get; set; }
        [ForeignKey("QuestionSelectionId")]
        public virtual QuestionSelection QuestionSelection { get; set; }
    }
}
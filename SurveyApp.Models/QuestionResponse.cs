using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class QuestionResponse
    {
        [Key]
        public int Id { get; set; }
        
     
        public int QuestionResponseId { get; set; }

        [ForeignKey("QuestionResponseId")]
        public QuestionSelection QuestionSelection { get; set; }
    }
}
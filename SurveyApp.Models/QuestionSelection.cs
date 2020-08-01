using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class QuestionSelection
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
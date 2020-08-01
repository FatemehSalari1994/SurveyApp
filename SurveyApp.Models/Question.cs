using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }      
        public string Title { get; set; }
        public ICollection<QuestionSelection> QuestionSelections { get; set; }
        [ForeignKey("SurveyId")]
        public Survey Survey { get; set; }
    }
}
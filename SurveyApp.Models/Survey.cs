using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SurveyApp.Models
{
    public class Survey
    {
        public Survey()
        {
            Questions = new List<Question>();
        }
        [Key]
        public int Id { get; set; }
        public string CoordinatorId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Title { get; set; }
        public bool IsOpen { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    
    }
}

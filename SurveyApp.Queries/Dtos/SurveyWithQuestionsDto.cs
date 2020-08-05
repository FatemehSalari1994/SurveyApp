using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Queries.ViewModels
{
    public class SurveyWithQuestionsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<QuestionDto> Questions { get; set; }

    }

    public class QuestionDto
    {
        public string Title { get; set; }
        public IList<QuestionSelectionDto> Selections { get; set; }
    }

    public class QuestionSelectionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}

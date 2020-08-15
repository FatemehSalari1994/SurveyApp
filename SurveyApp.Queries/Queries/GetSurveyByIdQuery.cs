using SurveyApp.Data.Contracts;
using SurveyApp.Data.Implementations;
using SurveyApp.Queries.Contracts;
using SurveyApp.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Queries.Queries
{
    public class GetSurveyByIdQuery : IGetSurveyByIdQuery
    {
        ISurveyDbContext _surveyDbContext;
        public GetSurveyByIdQuery(ISurveyDbContext surveyDbContext)
        {
            _surveyDbContext = surveyDbContext;
        }

        public async Task<SurveyWithQuestionsDto> Execute(int id)
        {
            var query = await _surveyDbContext.Surveys.FindAsync(id);
            return  new SurveyWithQuestionsDto
                    {
                        Title = query.Title,
                        Id = query.Id,
                        Questions = query.Questions.Select(q => new QuestionDto
                        {
                            Id=q.Id,
                            Title = q.Title,
                            Selections = q.QuestionSelections.Select(_=> new QuestionSelectionDto
                            {
                                Id=_.Id,
                                Title=_.Title
                            }).ToList()
                        }).ToList() 
                    };
        }
    }
}

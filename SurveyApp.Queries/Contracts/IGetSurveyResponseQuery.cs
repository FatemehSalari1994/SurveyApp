using SurveyApp.Queries.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Queries.Contracts
{
    public interface IGetSurveyResponseQuery
    {
        Task<SurveyResponseDto> Execute(int id);
    }
}

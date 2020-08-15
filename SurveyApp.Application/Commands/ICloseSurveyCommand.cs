using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Commands
{
    public interface ICloseSurveyCommand 
    {
        Task Execute(int id);
    }
}

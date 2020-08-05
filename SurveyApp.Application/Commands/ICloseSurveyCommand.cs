using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Commands
{
    public interface ICloseSurveyCommand 
    {
        void Execute(int id);
    }
}

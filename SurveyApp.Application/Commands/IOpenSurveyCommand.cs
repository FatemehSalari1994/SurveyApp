using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyApp.Application.Commands
{
    public interface IOpenSurveyCommand
    {
        void Execute(int id);
    }
}

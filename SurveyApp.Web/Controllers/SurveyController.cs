using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SurveyApp.Application.Commands;
using SurveyApp.Application.Commands.ViewModels;
using SurveyApp.Queries.Contracts;

namespace SurveyApp.Web.Controllers
{
    public class SurveyController : Controller
    {
        IDefineSurveyCommand _defineSurveyCommand;
        IGetOpenSurveysQuery _getOpenSurveyQuery;
        IGetCloseSurveysQuery _getCloseSurveyQuery;
        IGetSurveyByIdQuery _getSurveyByIdQuery;
        IAddQuestionToSurveyCommand _addQuestionToSurveyCommand;
        IOpenSurveyCommand _openSurveyCommand;
        ICloseSurveyCommand _closeSurveyCommand;
        IGetSurveyResponseReportQuery _getSurveyResponseReportQuery;
        IResponseSurveyCommand _responseSurveyCommand;
        public SurveyController(IDefineSurveyCommand defineSurveyCommand,
                                IGetOpenSurveysQuery getOpenSurveyQuery,
                                IGetSurveyByIdQuery getSurveyByIdQuery,
                                IAddQuestionToSurveyCommand addQuestionToSurveyCommand,
                                IGetCloseSurveysQuery getCloseSurveyQuery,
                                IOpenSurveyCommand openSurveyCommand,
                                ICloseSurveyCommand closeSurveyCommand,
                                IGetSurveyResponseReportQuery GetSurveyResponseReportQuery,
                                IResponseSurveyCommand responseSurveyCommand)
        {
            _defineSurveyCommand = defineSurveyCommand;
            _getOpenSurveyQuery = getOpenSurveyQuery;
            _getSurveyByIdQuery = getSurveyByIdQuery;
            _addQuestionToSurveyCommand = addQuestionToSurveyCommand;
            _getCloseSurveyQuery = getCloseSurveyQuery;
            _openSurveyCommand = openSurveyCommand;
            _closeSurveyCommand = closeSurveyCommand;
            _getSurveyResponseReportQuery = GetSurveyResponseReportQuery;
            _responseSurveyCommand = responseSurveyCommand;
        }

        public IActionResult Define()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Define(SurveyViewModel surveyViewModel)
        {
            await _defineSurveyCommand.Execute(surveyViewModel);
            return RedirectToAction("ShowOpenSurveys");
        }

        public async Task<IActionResult> ShowOpenSurveys()
        {
            return View(await _getOpenSurveyQuery.Execute());
        }

        public async Task<IActionResult> ShowCloseSurveys()
            => View(await _getCloseSurveyQuery.Execute());
        

        public IActionResult AddQuestion(int id)
            => View();
        

        [HttpPost]
        public async Task<IActionResult> AddQuestion(int id,QuestionViewModel questionViewModel)
        {
            questionViewModel.SelectionsTitles = questionViewModel.SelectionsTitles[0].Split(',');
            await _addQuestionToSurveyCommand.Execute(id,questionViewModel);
            return RedirectToAction("ShowOpenSurveys");
        }

        public async Task<IActionResult> ShowDetails(int id)
            => View(await _getSurveyByIdQuery.Execute(id));
        

        public async Task<IActionResult> Open(int id)
        {
            await _openSurveyCommand.Execute(id);
            return RedirectToAction("ShowOpenSurveys");
        }

        public async Task<IActionResult> Close(int id)
        {
            await _closeSurveyCommand.Execute(id);
            return RedirectToAction("ShowOpenSurveys");
        }

        public async Task<IActionResult> Report(int id)
            => View(await _getSurveyResponseReportQuery.Execute(id));
        

        public async Task<IActionResult> ResponseSurvey(int id)
            => View(await _getSurveyByIdQuery.Execute(id));
        

        [HttpPost]
        public async Task<IActionResult> ResponseSurvey(int id,SurveyResponseViewModel surveyResponseViewModel)
        {
            await _responseSurveyCommand.Execute(id, surveyResponseViewModel);
            return RedirectToAction("ShowOpenSurveys");
        }

    }
}
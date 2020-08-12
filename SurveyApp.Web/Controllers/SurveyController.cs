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
        public IActionResult Define(SurveyViewModel surveyViewModel)
        {
            _defineSurveyCommand.Execute(surveyViewModel);
            return RedirectToAction("ShowOpenSurveys");
        }

        public ActionResult ShowOpenSurveys()
        {
            return View(_getOpenSurveyQuery.Execute());
        }

        public ActionResult ShowCloseSurveys()
        {
            return View(_getCloseSurveyQuery.Execute());
        }

        public IActionResult AddQuestion(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestion(int id,QuestionViewModel questionViewModel)
        {
            questionViewModel.SelectionsTitles = questionViewModel.SelectionsTitles[0].Split(',');
            _addQuestionToSurveyCommand.Execute(id,questionViewModel);
            return RedirectToAction("ShowOpenSurveys");
        }

        public IActionResult ShowDetails(int id)
        {
            return View(_getSurveyByIdQuery.Execute(id));
        }

        public IActionResult Open(int id)
        {
            _openSurveyCommand.Execute(id);
            return RedirectToAction("ShowOpenSurveys");
        }

        public IActionResult Close(int id)
        {
            _closeSurveyCommand.Execute(id);
            return RedirectToAction("ShowOpenSurveys");
        }

        public IActionResult Report(int id)
        {
            return View(_getSurveyResponseReportQuery.Execute(id));
        }

        public IActionResult ResponseSurvey(int id)
        {

            return View(_getSurveyByIdQuery.Execute(id));
        }

        [HttpPost]
        public IActionResult ResponseSurvey(int id,SurveyResponseViewModel surveyResponseViewModel)
        {
            _responseSurveyCommand.Execute(id, surveyResponseViewModel);
            return RedirectToAction("ShowOpenSurveys");
        }

    }
}
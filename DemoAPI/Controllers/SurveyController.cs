using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAPI.Core.Contracts.ServiceContract;
using DemoAPI.Core.Model;
using DemoAPI.Core.ViewModels.AccountViewModel;
using DemoAPI.Core.ViewModels.Survey;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyContract service;

        public SurveyController(ISurveyContract questionService)
        {
            service = questionService;
        }

        #region Suvey 

        [HttpPost("create_survey")]
        public IActionResult CreateSurvey([FromBody] CreateSurveyViewModel survey)//CreateProperViewModel
        {
            return Ok(service.SaveSurvey(survey));
        }

        [HttpPost("update_survey")]
        public IActionResult UpdateSurvey([FromBody] UpdateSurveyViewModel updatedSurvey)
        {
            return Ok(service.UpdateSurvey(updatedSurvey));
        }

        [HttpPost("remove_survey/{surveyId}")]
        public ActionResult removeSurvey(string surveyId)
        {
            return Ok(service.RemoveSurvey(surveyId));
        }

        [HttpPost("get_surveys")]
        public ActionResult GetSurveys()
        {
            return Ok(service.GetSurveys());
        }

        [HttpPost("get_survey_by_id/{id}")]
        public ActionResult GetSsurveyById(string id)
        {
            return Ok(service.GetSurveyById(id));
        }

        #endregion
    }
}
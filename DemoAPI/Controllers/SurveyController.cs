using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surve.Domain.Contracts;
using mod = Survey.Core.Model;

namespace API.SurveyApi.Controllers
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
        public IActionResult CreateSurvey([FromBody] mod.Survey survey)//CreateProperViewModel
        {
            return Ok(service.SaveSurvey(survey));
        }

        [HttpPost("update_survey")]
        public IActionResult UpdateSurvey([FromBody] mod.Survey updatedSurvey)
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
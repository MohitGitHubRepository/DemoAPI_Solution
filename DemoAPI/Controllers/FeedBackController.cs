using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Surve.Domain.Contracts;
using Survey.Core.Model;

namespace API.SurveyApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedbackService service;

        public FeedBackController(IFeedbackService _feedback)
        {
            service = _feedback;
        }
        #region Feedback 

        [HttpPost("create_feedback")]
        public IActionResult CreateSurvey([FromBody] Feedback createFeedback) 
        {
            return Ok(service.SaveFeedback(createFeedback));
        }

        [HttpPost("update_feedback")]
        public IActionResult UpdateSurvey([FromBody]Feedback updatedFeedback)
        {
            return Ok(service.UpdateFeedback(updatedFeedback));
        }

        [HttpPost("remove_feedback/{feedbackId}")]
        public ActionResult removeSurvey(string feedbackId)
        {
            return Ok(service.RemoveFeedback(feedbackId));
        }

        [HttpPost("get_feedbacks")]
        public ActionResult GetSurveys()
        {
            return Ok(service.GetFeedback());
        }

        [HttpPost("get_feedback_by_id/{id}")]
        public ActionResult GetSsurveyById(string id)
        {
            return Ok(service.GetFeedbackById(id));
        }

        [HttpPost("get_feedback_by_servey_id/{id}")]
        public ActionResult GetFeedbackBySurveyId(string id)
        {
            return Ok(service.GetFeedbackById(id));
        }

        #endregion
    }
}
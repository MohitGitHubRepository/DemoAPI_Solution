using DemoAPI.Core.Model;
using DemoAPI.Core.ViewModels.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Core.Contracts.ServiceContract
{
    public interface IFeedbackService
    {
        List<Feedback> GetFeedback();
        List<Feedback> GetFeedbacksBySurveyId(string Id);
        Feedback GetFeedbackById(string Id);
        string SaveFeedback(CreateFeedBackViewModel feedback);
        string UpdateFeedback(UpdateFeedBackViewModel feedback);
        string RemoveFeedback(string Id);
    }
}

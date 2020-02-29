using Survey.Core.Model;
using System.Collections.Generic;

namespace Surve.Domain.Contracts
{
    public interface IFeedbackService
    {
        List<Feedback> GetFeedback();
        List<Feedback> GetFeedbacksBySurveyId(string Id);
        Feedback GetFeedbackById(string Id);
        string SaveFeedback(Feedback feedback);
        string UpdateFeedback(Feedback feedback);
        string RemoveFeedback(string Id);
    }
}

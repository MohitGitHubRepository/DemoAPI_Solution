using Surve.Domain.Contracts;
using Survey.Core.Model;
using Survey.DataAccess.SQL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Domain.APIServices
{
    public class FeedbackService : IFeedbackService
    {

        IRepository<Feedback> repository;

        public FeedbackService(IRepository<Feedback> Repository)
        {
            this.repository = Repository;
        }

        public List<Feedback> GetFeedback()
        {
            return repository.Collection().ToList();
        }

        public Feedback GetFeedbackById(string Id)
        {
            return GetFeedback().Where(a => a.Id == Id).FirstOrDefault();
        }

        public List<Feedback> GetFeedbacksBySurveyId(string Id)
        {
            return GetFeedback().Where(a => a.SurveyId == Id).ToList();
        }

        public string RemoveFeedback(string Id)
        {
            try
            {
                Feedback feedback = GetFeedbackById(Id);
                if (feedback != null)
                {
                    this.repository.Delete(feedback);
                    repository.Commit();
                    return "Details Updted Successfully";
                }
                else
                {
                    return "feedback Does Not Exists";
                }

            }
            catch
            {
                throw new Exception("Not Updated");
            }
        }

        public string SaveFeedback(Feedback createFeedback)
        {
            try
            {
                repository.Insert(createFeedback);
                repository.Commit();
                return "Details saved successfully";
            }
            catch
            {
                //Exception
                return "Email Id or phone number already registered";
            }
        }

        public string UpdateFeedback(Feedback updateFeedback)
        {
            try
            {
                Feedback feedback = GetFeedbackById(updateFeedback.Id);
                if (feedback == null)
                {
                    return "Survey Does Not Exists";
                }
                else
                {
                    UpdateSurveyMap(updateFeedback, feedback);
                    this.repository.Edit(feedback);
                    repository.Commit();
                    return "Details Updted Successfully";
                }

            }
            catch
            {
                throw new Exception("Not Updated");
            }
        }

        private void UpdateSurveyMap(Feedback updateFeedback, Feedback feedback)
        {

            feedback.Age = updateFeedback.Age;
            feedback.Comment = updateFeedback.Comment;
            feedback.CommentDateTime = updateFeedback.CommentDateTime;
            feedback.CreatedBy = updateFeedback.CreatedBy;
            feedback.Evaluation = updateFeedback.Evaluation;
            feedback.Gender = updateFeedback.Gender;
            feedback.ModifiedDateTime = DateTime.Now;
            feedback.Name = updateFeedback.Name;
            feedback.Occupation = updateFeedback.Occupation;
            feedback.SurveyId = updateFeedback.SurveyId;

        }
    }
}

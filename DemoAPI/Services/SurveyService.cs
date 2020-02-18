using DemoAPI.Core.Contracts;
using DemoAPI.Core.Contracts.ServiceContract;
using DemoAPI.Core.Model;
using DemoAPI.Core.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Services
{
    public class SurveyService : ISurveyContract
    {

        IRepository<Survey> repository;
       
        public SurveyService(IRepository<Survey> Repository)
        {
            this.repository = Repository;
        }


        public Survey GetSurveyById(string Id)
        {
            return GetSurveys().Where(a => a.Id == Id).FirstOrDefault();
        }

        public List<Survey> GetSurveys()
        {
            return repository.Collection().ToList();
        }

        public List<Survey> GetSurveysByCategory(string category)
        {
            return GetSurveys().Where(a => a.Category == category).ToList();
        }

        public string RemoveSurvey(string Id)
        {
            try
            {
                Survey survey = GetSurveyById(Id);
                if (survey != null)
                {
                    this.repository.Delete(survey);
                    repository.Commit();
                    return "Details Updted Successfully";
                }
                else
                {
                    return "Survey Does Not Exists";
                }

            }
            catch
            {
                throw new Exception("Not Updated");
            }
        }

        public string SaveSurvey(Survey survey)
        {
            try
            {
                repository.Insert(survey);
                repository.Commit();
                return "Details saved successfully";
            }
            catch
            {
                //Exception
                return "Email Id or phone number already registered";
            }
        }

        public string UpdateSurvey(UpdateSurveyViewModel updatedSurvey)
        {
            try
            {
                Survey survey = GetSurveyById(updatedSurvey.Id);
                if (survey == null)
                {
                    return "Survey Does Not Exists";
                }
                else
                {
                    UpdateSurveyMap(updatedSurvey, survey);
                    this.repository.Edit(survey);
                    repository.Commit();
                    return "Details Updted Successfully";
                }

            }
            catch
            {
                throw new Exception("Not Updated");
            }
        }

        private void UpdateSurveyMap(UpdateSurveyViewModel updatedSurvey, Survey survey)
        {
           
            survey.Name = updatedSurvey.Name;
            survey.SurveyDate = updatedSurvey.SurveyDate;
            survey.SurveyQuestion = updatedSurvey.SurveyQuestion;
            survey.Description = updatedSurvey.Description;
            survey.CreatedBy = updatedSurvey.CreatedBy;
            survey.Category = updatedSurvey.Category;
            survey.ModifiedDateTime = DateTime.Now;
        }
    }
}

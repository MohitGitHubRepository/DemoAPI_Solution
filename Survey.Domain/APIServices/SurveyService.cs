using Surve.Domain.Contracts;
using Survey.DataAccess.SQL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using mod = Survey.Core.Model;

namespace Survey.Domain.APIServices
{
    public class SurveyService : ISurveyContract
    {

        IRepository<mod.Survey> repository;
       
        public SurveyService(IRepository<mod.Survey> Repository)
        {
            this.repository = Repository;
        }


        public mod.Survey GetSurveyById(string Id)
        {
            return GetSurveys().Where(a => a.Id == Id).FirstOrDefault();
        }

        public List<mod.Survey> GetSurveys()
        {
            return repository.Collection().ToList();
        }

        public List<mod.Survey> GetSurveysByCategory(string category)
        {
            return GetSurveys().Where(a => a.Category == category).ToList();
        }

        public string RemoveSurvey(string Id)
        {
            try
            {
                mod.Survey survey = GetSurveyById(Id);
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

        public string SaveSurvey(mod.Survey createSurvey)
        {
            try
            {
                 
                //CreateSurveyMap(createSurvey, survey);
                repository.Insert(createSurvey);
                repository.Commit();
                return "Details saved successfully";
            }
            catch(Exception ex)
            {
                //Exception
                return "Email Id or phone number already registered";
            }
        }

        public string UpdateSurvey(mod.Survey updatedSurvey)
        {
            try
            {
                mod.Survey survey = GetSurveyById(updatedSurvey.Id);
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
        //private void CreateSurveyMap(CreateSurveyViewModel createSurvey, Survey survey)
        //{

        //    survey.Name = createSurvey.Name;
        //    survey.SurveyDate = createSurvey.SurveyDate;
        //    survey.SurveyQuestion = createSurvey.SurveyQuestion;
        //    survey.Description = createSurvey.Description;
        //    survey.CreatedBy = createSurvey.CreatedBy;
        //    survey.Category = createSurvey.Category;
        //    survey.ModifiedDateTime = DateTime.Now;
        //}

        private void UpdateSurveyMap(mod.Survey updatedSurvey, mod.Survey survey)
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

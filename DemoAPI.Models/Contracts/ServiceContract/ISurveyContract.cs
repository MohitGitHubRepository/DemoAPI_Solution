using DemoAPI.Core.Model;
using DemoAPI.Core.ViewModels.AccountViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Core.Contracts.ServiceContract
{
    public interface ISurveyContract
    {

        #region Survey

        List<Survey> GetSurveys();
        List<Survey> GetSurveysByCategory(string category);
        Survey GetSurveyById(string Id);
        string SaveSurvey(Survey survey);
        string UpdateSurvey(UpdateSurveyViewModel survey);
        string RemoveSurvey(string Id);

        #endregion

    }
}

using DemoAPI.Core.Model;
using DemoAPI.Core.ViewModels.Survey;
using System.Collections.Generic;

namespace DemoAPI.Core.Contracts.ServiceContract
{
    public interface ISurveyContract
    {

        #region Survey

        List<Survey> GetSurveys();
        List<Survey> GetSurveysByCategory(string category);
        Survey GetSurveyById(string Id);
        string SaveSurvey(CreateSurveyViewModel survey);
        string UpdateSurvey(UpdateSurveyViewModel survey);
        string RemoveSurvey(string Id);

        #endregion

    }
}

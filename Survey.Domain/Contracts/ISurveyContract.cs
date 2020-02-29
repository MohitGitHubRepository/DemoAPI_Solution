using mod=Survey.Core.Model;  
using System.Collections.Generic;

namespace Surve.Domain.Contracts
{
    public interface ISurveyContract
    {

        #region Survey

        List<mod.Survey> GetSurveys();
        List<mod.Survey> GetSurveysByCategory(string category);
        mod.Survey GetSurveyById(string Id);
        string SaveSurvey(mod.Survey survey);
        string UpdateSurvey(mod.Survey survey);
        string RemoveSurvey(string Id);

        #endregion

    }
}

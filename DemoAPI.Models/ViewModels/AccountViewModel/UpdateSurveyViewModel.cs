using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Core.ViewModels.AccountViewModel
{
    public class UpdateSurveyViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SurveyQuestion { get; set; }
        public DateTime SurveyDate { get; set; }
        public string CreatedBy { get; set; }
    }
}

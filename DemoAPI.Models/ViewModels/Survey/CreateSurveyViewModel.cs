using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoAPI.Core.ViewModels.Survey
{
    public class CreateSurveyViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string SurveyQuestion { get; set; }
        [Required]
        public DateTime SurveyDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}

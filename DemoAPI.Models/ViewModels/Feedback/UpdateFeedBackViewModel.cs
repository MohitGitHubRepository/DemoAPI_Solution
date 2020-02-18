using DemoAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoAPI.Core.ViewModels.Feedback
{
    public class UpdateFeedBackViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string SurveyId { get; set; }
        
        public string Name { get; set; }
        
        public string Gender { get; set; }
       
        public string Age { get; set; }
         
        public string Occupation { get; set; }
        
        public string Comment { get; set; }
        public DateTime CommentDateTime { get; set; }
        public Evaluations Evaluation { get; set; }
        public string CreatedBy { get; set; }
    }
}

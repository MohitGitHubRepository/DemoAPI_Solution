using DemoAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoAPI.Core.ViewModels.Feedback
{
    public class CreateFeedBackViewModel
    {
        [Required]
        public string SurveyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Occupation { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public DateTime CommentDateTime { get; set; }
        [Required]
        public Evaluations Evaluation { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}

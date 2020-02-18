using DemoAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Core.Model
{
    public class Feedback:BaseEntity
    {
        public Feedback():base()
        {

        }
        public string SurveyId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Occupation { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDateTime { get; set; }
        public Evaluations Evaluation { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        //Navigation Property
        public virtual Survey Survey { get; set; } 

    }
    public enum Evaluations
    {
        Excellent,
        Good,
        Bad,
        VeryBad
    }
}

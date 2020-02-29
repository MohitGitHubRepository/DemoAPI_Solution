using System;
using System.Collections.Generic;

namespace Survey.Core.Model
{
    public class Survey :BaseEntity
    {
        public Survey() : base()
        {
            Feedbacks = new HashSet<Feedback>();
            this.ModifiedDateTime = DateTime.Now;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SurveyQuestion { get; set; }
        public DateTime SurveyDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime ModifiedDateTime { get; set; }

        //Navigation Property
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}

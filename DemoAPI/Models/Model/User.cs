using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoAPI.Models
{
    public class User :BaseEntity
    {
        public User():base()
        {

        }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
             
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

       
        public DateTimeOffset? ModifiedDateTime;
    }
}

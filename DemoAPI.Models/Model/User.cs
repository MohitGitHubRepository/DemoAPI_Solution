using System;

namespace Survey.Core.Model
{
    public class User :BaseEntity
    {
        public User():base()
        {

        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public DateTime ModifiedDateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Core.ViewModels.AccountViewModel
{
    public class LoggedInUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}

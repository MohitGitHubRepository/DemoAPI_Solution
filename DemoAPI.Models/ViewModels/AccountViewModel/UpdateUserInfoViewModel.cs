using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Core.ViewModels.AccountViewModel
{
    public class UpdateUserInfoViewModel
    {
        //Will be modified later for updating more information
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
    }
}

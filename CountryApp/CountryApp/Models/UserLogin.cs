using System;
using System.Collections.Generic;
using System.Text;

namespace CountryApp.Models
{
    class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public partial class LoginModel
    {
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}

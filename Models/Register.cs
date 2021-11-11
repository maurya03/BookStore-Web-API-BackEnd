using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Register
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public int mobile { get; set; }


        public Register() { }

        public Register(string userName, string email, string password, int mobile)
        {
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.mobile = mobile;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int mobile { get; set; }

        public User() { }

        public User(int userId, string userName, string email, string password, int mobile)
        {
            this.userId = userId;
            this.userName = userName;
            this.email = email;
            this.password = password;
            this.mobile = mobile;
        }
    }
}
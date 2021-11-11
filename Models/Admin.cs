using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Admin
    {
        public string email { get; set; }
        public string password { get; set; }

        public Admin() { }

        public Admin( string e, string p)
        {
            email = e;
            password = p;
        }
    }
}
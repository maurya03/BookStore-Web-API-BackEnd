using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Models
{
    public class RegisterSqlImp : IRegisterRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public RegisterSqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public string login(Register user)
        {
            //List<Register> list = new List<Register>();
            comm.CommandText = "select * from [user] where email = '" + user.email + "' and password = '" + user.password + "' ";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.Read())
            {
                return "LoggedIn Successfully!!";
                conn.Close();
            }
            else
            {
                return "Please Enter Valid Email and Password!!";
                conn.Close();
            }
        }

        public int register(Register register)
        {
            comm.CommandText = "insert into [user] (userName, email, password, mobile) values ('" + register.userName + "', '" + register.email + "','" + register.password + "', '" + register.mobile + "')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }
    }
}
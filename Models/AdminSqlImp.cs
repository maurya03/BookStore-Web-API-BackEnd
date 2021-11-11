using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Models
{
    public class AdminSqlImp : IAdminRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public AdminSqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public List<Admin> GetAllAdmins()
        {
            List<Admin> list = new List<Admin>();
            comm.CommandText = "select * from admin";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                 
                string userName = dr["email"].ToString();
                string password = dr["password"].ToString();
                list.Add(new Admin(userName, password));
            }
            conn.Close();
            return list;
        }
    }
}
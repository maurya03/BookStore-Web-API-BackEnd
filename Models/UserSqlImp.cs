using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Models
{
    public class UserSqlImp : IUserRepository
    {

        SqlConnection conn;
        SqlCommand comm;

        public UserSqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public User AddUsers(User user)
        {
            string res;
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "insert into [user] values('" + user.userName + "','" + user.email + "','" + user.password + "'," + user.mobile + ")";
                conn.Open();
                //SqlDataReader dr = comm.ExecuteReader();
                int row = comm.ExecuteNonQuery();
                res = "'" + row + "' affected!!";
            }
            return user;
        }

        public void DeleteUsers(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "delete from [user] where userId = " + id;
                conn.Open();
                int row = comm.ExecuteNonQuery();
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            comm.CommandText = "select * from [user]";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int userId = Convert.ToInt32(dr["userId"]);
                int mobile = Convert.ToInt32(dr["mobile"]);
                string userName = dr["userName"].ToString();
                string password = dr["password"].ToString();

                //int cStatus = Convert.ToInt32(binary,2);

                string email = dr["email"].ToString();

                list.Add(new User(userId, userName, email, password, mobile));
            }
            conn.Close();
            return list;
        }

        public User GetUsersById(int id)
        {
            User user = new User();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from [user] where userId = " + id;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    user.userId = dr.GetInt32(0);
                    user.userName = dr.GetString(1);
                    user.email = dr.GetString(2);
                    user.password = dr.GetString(3);
                    user.mobile = dr.GetInt32(4);
                }
            }
            return user;
        }

        public void UpdateUsers(int id, User user)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "Update [user] set userName='" + user.userName + "',email='" + user.email + "',password = '" + user.password + "',mobile = " + user.mobile + " where userId = " + id;
                conn.Open();
                comm.ExecuteNonQuery();
            }
        }
    }
}
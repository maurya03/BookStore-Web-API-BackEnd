using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Models
{
    public class CartSqlImp : ICartRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public CartSqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public int AddCart(Cart cart)
        {
            
             
           comm.CommandText = "insert into cart(userId,bookId,Quantity, Total) values(" + cart.userId + ", " + cart.bookId + ", " + cart.Quantity + ", "+cart.Total+")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;

        }

        public int DaleteCart(int id)
        {
            int row;
            using (conn)
            {

                comm.CommandText = "delete from cart where cartId = " + id + " ";
                comm.Connection = conn;
                conn.Open();
                row = comm.ExecuteNonQuery();
            }
            return row;
        }

        public List<Cart> GetAllCarts()
        {
            List<Cart> list = new List<Cart>();
            comm.CommandText = "select * from cart";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int userId = Convert.ToInt32(dr["userId"]);
                int bookId = Convert.ToInt32(dr["bookId"]);
                int quantity = Convert.ToInt32(dr["Quantity"]);
                int Total = Convert.ToInt32(dr["Total"]);
                //int cStatus = Convert.ToInt32(binary,2);

                 

                list.Add(new Cart(userId, bookId, quantity, Total));
            }
            conn.Close();
            return list;
        }

        public Cart GetCartById(int id)
        {
            Cart cart = new Cart();
            string connectionString = ConfigurationManager.ConnectionStrings["mydb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "select * from cart where cartId = " + id;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    cart.userId = dr.GetInt32(0);
                    cart.bookId = dr.GetInt32(1);
                    cart.Quantity = dr.GetInt32(2);
                    cart.Total = dr.GetInt32(3);
                }
            }
            return cart;
        }

        public int updateCart(int id, Cart cart)
        {
            int row;
            using (conn)
            {

                comm.Connection = conn;
                comm.CommandText = "Update cart set Quantity=" + cart.Quantity + ",Total=" + cart.Total + ",userId=" + cart.userId + ", bookId=" + cart.bookId + " where cartId = " + id;
                conn.Open();
                row = comm.ExecuteNonQuery();

            }
            return row;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace WebApplication1.Models
{
    public class CategorySqlImp : ICategoryRepository
    {


        SqlConnection conn;
        SqlCommand comm;

        public CategorySqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }

        public int AddCategory(Category category)
        {
            comm.CommandText = "insert into category(catName, description, imageName,catStatus, position, createdAt) values ('" + category.catName + "','" + category.description + "','" + category.imageName + "',"+Convert.ToInt32(category.catStatus)+","+category.position+",'"+category.createdAt+"')";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        public int DeleteCategory(int catId)
        {
            int row;
            using (conn)
            {

                comm.CommandText = "delete from CATEGORY where catId = " + catId + " ";
                comm.Connection = conn;
                conn.Open();
                row = comm.ExecuteNonQuery();
            }
            return row;
        }

        public List<Category> GetAllCategories()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from CATEGORY";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["catId"]);
                string catName = dr["catName"].ToString();
                DateTime createdAt = Convert.ToDateTime(dr["createdAt"]);
                string desc = dr["description"].ToString();
                int position = Convert.ToInt32(dr["position"]);

                Boolean binary = Convert.ToBoolean(dr["catStatus"]);

                //int cStatus = Convert.ToInt32(binary,2);
                string imgName = dr["imageName"].ToString();

                list.Add(new Category(id, catName, desc, imgName, position, binary, createdAt));
            }
            conn.Close();
            return list;


            //int catId, string catName, string desc, string img, int position, /*bool catStatus,*/ DateTime createdAt
        }

        public Category GetCategoryById(int catId)
        {
            Category category = null;
            using (conn)
            {
                comm.CommandText = "Select * from CATEGORY where catId = " + catId + "";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    category = new Category();
                    category.catId = dr.GetInt32(0);
                    category.catName = dr.GetString(1);
                    category.description = dr.GetString(2);
                    category.imageName = dr.GetString(3);
                    category.catStatus = dr.GetBoolean(4);
                    category.position = dr.GetInt32(5);
                    category.createdAt = dr.GetDateTime(6);


                }
            }
            return category;
        }

        public int UpdateCategory(int id, Category category)
        {
            int row;
            using (conn)
            {

                comm.Connection = conn;
                comm.CommandText = "Update category set catName='" + category.catName + "',description='" + category.description + "',imageName='" + category.imageName + "', catStatus='" + category.catStatus+ "',position='" + category.position + "',createdAt='" + category.createdAt + "' where catId = " + id;
                conn.Open();
                row = comm.ExecuteNonQuery();

            }
            return row;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Models
{
    public class BookSqlImp : IBookRepository
    {
        SqlConnection conn;
        SqlCommand comm;

        public BookSqlImp()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }



        public List<Book> getBookBycatId(int catid)
        {
            List<Book> book = new List<Book>(); ;
            using (conn)
            {
                comm.CommandText = "Select book.bookId, book.ISBN, book.title, book.publicationYear, book.price, book.bookDesc, book.bookPosition, book.bookStatus, book.imageName, book.catId, book.author from category inner join book on category.catId=book.catId where category.catId = " + catid + "";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["bookId"]);
                    int isbn = Convert.ToInt32(dr["ISBN"]);
                    string title = dr["title"].ToString();
                    DateTime publicationYear = Convert.ToDateTime(dr["publicationYear"]);
                    int price = Convert.ToInt32(dr["price"]);
                    string desc = dr["bookDesc"].ToString();
                    int position = Convert.ToInt32(dr["bookPosition"]);
                    Boolean bStatus = Convert.ToBoolean(dr["bookStatus"]);
                    string imgName = dr["imageName"].ToString();
                    int catId = Convert.ToInt32(dr["catId"]);
                    string author = dr["author"].ToString();
                     
                     
                    book.Add(new Book(isbn, title, publicationYear, desc, price, position, bStatus, imgName, author, catId));

                }
            }
            return book;
        }


        public int AddBook(Book book)
        {
            comm.CommandText = "insert into book (ISBN, Title, publicationYear, bookDesc, price, bookPosition, bookStatus, imageName, author, catId) values (" + book.ISBN + ", '" + book.Title + "', '" + book.publicationYear + "', '" + book.bookDescription + "', " + book.Price + ", " + book.bookPosition + ", " + Convert.ToInt32(book.bookStatus) + ", '" + book.imageName + "', '" + book.author + "', " + book.catId + ")";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            return row;
        }

      

        public int DeleteBook(int id)
        {
            int row;
            using (conn)
            {
                comm.CommandText = "delete from book where bookId = " + id + " ";
                comm.Connection = conn;
                conn.Open();
                row = comm.ExecuteNonQuery();
            }
            return row;
        }

        

        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            comm.CommandText = "select * from book";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["bookId"]);
                int isbn = Convert.ToInt32(dr["ISBN"]);
                string title = dr["title"].ToString();
                DateTime publicationYear = Convert.ToDateTime(dr["publicationYear"]);
                string desc = dr["bookDesc"].ToString();
                int position = Convert.ToInt32(dr["bookPosition"]);
                Boolean bStatus = Convert.ToBoolean(dr["bookStatus"]);
                string imgName = dr["imageName"].ToString();
                string author = dr["author"].ToString();
                int price = Convert.ToInt32(dr["price"]);
                int catId = Convert.ToInt32(dr["catId"]);
                list.Add(new Book(isbn, title, publicationYear, desc, price,position, bStatus,imgName, author, catId));
            }
            conn.Close();
            return list;

            //    int bookId, string Title, DateTime publicationYear, string bookDescription, int price, int bookPosition, bool bookStatus, string imageName, string author, int catId)
            //
        }

        

        public Book GetBookById(int id)
        {
            Book book = null;
            using (conn)
            {
                comm.CommandText = "Select * from book where bookId = " + id + "";
                comm.Connection = conn;
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                while (dr.Read())
                {
                    book = new Book();
                    book.bookId = dr.GetInt32(0);
                    book.ISBN = dr.GetInt32(1);
                    book.Title = dr.GetString(2);
                    book.publicationYear = dr.GetDateTime(3);
                    book.Price = Convert.ToInt32(dr.GetDecimal(4));
                    book.bookDescription = dr.GetString(5);
                    book.bookPosition = dr.GetInt32(6);
                    book.bookStatus = dr.GetBoolean(7);
                    book.imageName = dr.GetString(8);
                    book.catId = dr.GetInt32(9);
                    book.author = dr.GetString(10);


                }
            }
            return book;
        }

         
        public int UpdateBook(int id, Book book)
        {
            int row;
            using (conn)
            {

                comm.Connection = conn;
                comm.CommandText = "Update book set ISBN='" + book.ISBN + "',title='" + book.Title + "',publicationYear='"+ book.publicationYear + "', price='"+ book.Price + "',bookDesc='"+ book.bookDescription + "',bookPosition='"+ book.bookPosition + "',bookStatus='"+ book.bookStatus + "',imageName='"+ book.imageName + "',catId='"+ book.catId + "',author='"+ book.author + "' where bookId = " + id;
                conn.Open();
                row = comm.ExecuteNonQuery();

            }
            return row;
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        int AddBook(Book book);
        int UpdateBook(int id, Book book);
        int DeleteBook(int id);

        List<Book> getBookBycatId(int catid);


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Web.Http.Cors;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BookController : ApiController
    {

        private IBookRepository repository;

        public BookController()
        {
            repository = new BookSqlImp();
        }

        [HttpGet]
        [Route("book")]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllBooks();
            return Ok(data);
        }

        [HttpGet]
        [Route("bookByCatId/{catId}")]
        public List<Book> GetCategory(int catId)
        {
            return repository.getBookBycatId(catId);
           
        }

        [HttpPost]
        [Route("book")]
        public HttpResponseMessage PostBook(Book book)
        {
            var row = repository.AddBook(book);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sorry! Could not add new record.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Book record added!");
            }
        }

        [HttpGet]
        [Route("book/{id}")]
        public Book GetBook(int id)
        {
            return repository.GetBookById(id);

        }

        [HttpPut]
        [Route("book/{id}")]
        public HttpResponseMessage Put(int id, Book book)
        {
            var row = repository.UpdateBook(id, book);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book id does not exist");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Book record updated!");
            }

        }

        [HttpDelete]
        [Route("book/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var row = repository.DeleteBook(id);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category id does not exist");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Record updated!");
            }
        }
    }
}

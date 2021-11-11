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
    public class CartController : ApiController
    {

        private ICartRepository repository;

        public CartController()
        {
            repository = new CartSqlImp();
        }

        [HttpGet]
        [Route("cart/{id}")]
        public Cart Get(int id)
        {
            return repository.GetCartById(id);
        }

        [HttpGet]
        [Route("cart")]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllCarts();
            return Ok(data);
        }

        [HttpPost]
        [Route("cart")]
        public HttpResponseMessage PostBook(Cart cart)
        {
            var row = repository.AddCart(cart);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Sorry! Could not add new record.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Book record added!");
            }
        }


        [HttpDelete]
        [Route("cart/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var row = repository.DaleteCart(id);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Category id does not exist");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Record updated!");
            }
        }


        [HttpPut]
        [Route("cart/{id}")]
        public HttpResponseMessage Put(int id, Cart cart)
        {
            var row = repository.updateCart(id, cart);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book id does not exist");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Book record updated!");
            }

        }
    }
}

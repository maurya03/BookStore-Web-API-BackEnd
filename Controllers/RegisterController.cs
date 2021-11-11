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
    public class RegisterController : ApiController
    {
        private IRegisterRepository repository;

        public RegisterController()
        {
            repository = new RegisterSqlImp();
        }
        [HttpGet]
        public string Get()
        {
            return "test";
        }

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage PostRegister(Register user)
        {
            var row = repository.register(user);
            if (row <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "something went wrong");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "successfully registered");

            }
        }

        [HttpPost]
        [Route("login")]
        public string PostLogin(Register user)
        {
            return repository.login(user);
        }
    }
}

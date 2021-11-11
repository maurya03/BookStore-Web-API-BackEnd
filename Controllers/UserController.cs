using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private IUserRepository repository;
        public UserController()
        {
            repository = new UserSqlImp();
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var data = repository.GetAllUsers();
            return Ok(data);
        }
        [HttpPost]
        public User Post(User user)
        {
            return repository.AddUsers(user);
        }
        [HttpGet]
        public User Get(int id)
        {
            return repository.GetUsersById(id);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            repository.DeleteUsers(id);
        }

        [HttpPut]
        public void Put(int id, User user)
        {
            repository.UpdateUsers(id, user);
        }
    }
}

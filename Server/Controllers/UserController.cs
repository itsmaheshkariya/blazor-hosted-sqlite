using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fullstack.Server.Models;
using Fullstack.Shared;
namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserContext _userContext;
        public UserController(UserContext userContext)
        {
            _userContext =userContext;
        }

        // GET api/user
        [HttpGet("")]
        public ActionResult<List<User>> Getstrings()
        {
            return _userContext.Users.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> GetstringById(int id)
        {
            return _userContext.Users.FirstOrDefault(user => user.Id == id);
        }

        // POST api/user
        [HttpPost("")]
        public ActionResult<User> Poststring(User user)
        {
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
            return user;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult<User> Putstring(int id, User user)
        {
            User newUser = _userContext.Users.FirstOrDefault(user => user.Id ==id);
            newUser.Name = user.Name;
            newUser.Email = user.Email;
            newUser.Password = user.Password;
            _userContext.SaveChanges();
            return newUser;

        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
            User oldUser = _userContext.Users.FirstOrDefault(user => user.Id == id);
            _userContext.Users.Remove(oldUser);
            _userContext.SaveChanges();
        }
    }
}

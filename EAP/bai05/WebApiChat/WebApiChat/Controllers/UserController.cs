using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiChat.Controllers
{
    public class UserController : ApiController
    {
        private DbChat context = new DbChat();
        [HttpGet]
        //https://localhost:44348/api/user?Username=hoangnd&Password=123456
        //chuc nang login
        public bool Get(string Username, string Password) {            
            return context.tblUsers
                .Where(user => user.UserName == Username && user.Password == Password)
                .ToList().Count > 0;
        }
        [HttpPost]
        public string Register(string Username, string Password)
        {
            try {
                if (context.tblUsers
                .Where(user => user.UserName == Username && user.Password == Password)
                .ToList().Count > 0)
                {
                    return "User exists";
                }
                context.tblUsers.Add(new User()
                {
                    UserName = Username,
                    Password = Password,
                });
                context.SaveChanges();
                return "";
            } catch(Exception e) {
                return e.ToString();
            }
            
        }
    }
}

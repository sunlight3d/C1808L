using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiChat.Controllers
{
    public class ChatsController : ApiController
    {
        //test by postman
        private DbChat context = new DbChat();
        //https:localhost: port/api/chats/
        [HttpGet]
        public IEnumerable<Chat> Get()
        {
            var chats = context.tblChats.ToList();
            return chats;
        }
        //https:localhost: port/api/chats/10
        public Chat Get(int id)
        {
            return context.tblChats.Where(chat => chat.Id == id).FirstOrDefault();
        }
        [HttpPost]
        public IHttpActionResult Post(string Content, string UserName)
        {
            try
            {
                var newChat = new Chat()
                {
                    Content = Content,
                    UserName = UserName,
                    SentTime = DateTime.Now
                };
                context.tblChats.Add(newChat);
                context.SaveChanges();
                return Json(newChat);//Helper Method
            }
            catch (Exception e)
            {
                return new HttpActionResult(HttpStatusCode.InternalServerError, e.ToString());
            }

        }

    }

}

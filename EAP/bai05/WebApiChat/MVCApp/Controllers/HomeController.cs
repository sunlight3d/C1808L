using MVCApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        public static string baseUrl = "https://localhost:44348/api/";
        private HttpClient client = new HttpClient();

        private string urlChat = baseUrl + "Chats";
        private string urlUser = baseUrl + "user";
        
        public ActionResult Index()
        {
            return View();
        }
        //vao tu trinh duyet, request get
        [HttpGet]
        public ActionResult Login() {
            if (Session["LoginUser"] != null) {
                return RedirectToAction("Chat", "Home");
            }
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Chat()
        {
            var response = await client.GetAsync(urlChat);
            var stringResponse = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == true) {
                List<Chat> chats = JsonConvert.DeserializeObject<List<Chat>>(stringResponse);
                return View(chats);
            }            
            return View(new List<Chat>());
        }
        //Khi nguoi dung bam login tren Form
        //Tham khao tiep buoi sau:
        //https://www.tutorialsteacher.com/webapi/consume-web-api-get-method-in-aspnet-mvc
        [HttpPost]
        public async Task<ActionResult> Login(User user) {
            //Phuong thuc nay se duoc goi khi nguoi dung bam Login
            //Gui request post len WebApi = MVCApp gui request POST den WebAPI
            //react => fetch,                                                                 
            var response = await client.GetAsync(urlUser + "?UserName="+user.UserName+"&Password="+user.Password);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == true && content.Equals("true")) {
                Session["LoginUser"] = user.UserName;
                return RedirectToAction("Chat", "Home");
            }
            return View(user);
        }
        [HttpPost]
        public async Task<ActionResult> SendChat(string Content) {
            //Goi api insert chat

            return RedirectToAction("Chat", "Home");
        }
    }
}        
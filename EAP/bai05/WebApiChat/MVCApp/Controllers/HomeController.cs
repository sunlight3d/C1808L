using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login() {
            return View();
        }
        //Khi nguoi dung bam login tren Form
        //Tham khao tiep buoi sau:
        //https://www.tutorialsteacher.com/webapi/consume-web-api-get-method-in-aspnet-mvc
        [HttpPost]
        public ActionResult Login(User user) {
            return View(user);
        }
    }
}        
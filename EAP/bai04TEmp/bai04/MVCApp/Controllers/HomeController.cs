using MVCApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        Service1Client client = new Service1Client();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            var result = client.Register(user.UserName, user.Password);
            if (ModelState.IsValid && result.Length > 0)
            {
                Session["LoginUser"] = user.UserName;
                return RedirectToAction("Chat", "Home");
            }
            else {
                ModelState.AddModelError("loginError", "Cannot register User");
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult AllChat()
        {
            var chats = client.GetAllChat();
            return View(chats);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid) {
                if (client.Login(user.UserName, user.Password))
                {
                    Session["LoginUser"] = user.UserName;
                    return RedirectToAction("Chat", "Home");
                }
                else {                    
                    ModelState.AddModelError("loginError", "Incorrect username/password");
                }
            } else {
                ModelState.AddModelError("loginError", "Invalid information");
            }
            return View(user);
        }
        
        


    }
}
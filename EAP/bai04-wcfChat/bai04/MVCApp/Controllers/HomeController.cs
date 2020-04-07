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
                    Session["UserName"] = user.UserName;
                    return RedirectToAction("Index", "Home");
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
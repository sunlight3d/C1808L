using MVCApp.ChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        //doi tuong tham chieu den WCF
        ChatService.Service1Client client = new ChatService.Service1Client();
        
        //moi method trong controller la 1 action = 1 view 
        public ActionResult Index()
        {
            return View();
        }
        //https:ip:port/api/Home/Login
        public ActionResult Login()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("Chat", "Home");//chuyen den View Chat = goi action Chat                
            }
            return View();//tuong ung voi Login.cshtml
        }
        //Khi nguoi dung bam nut login, gui request len controller => request post
        [HttpPost]
        //Gui cai gi len day ? Gui doi tuong user ma nguoi dung vua dien thong tin
        public ActionResult Login(User user) {            
            //check validate            
            if (ModelState.IsValid)
            {
                if (client.login(user.UserName, user.Password))
                {
                    //Luu session
                    
                    Session["UserName"] = user.UserName;//luu 1 object thi sao, object phai co Serializable
                    return RedirectToAction("Chat", "Home");//chuyen den View Chat = goi action Chat
                }
                else {
                    ModelState.AddModelError("LoginError", "Cannot login to your account");
                    //phai co cho hien thi loi nay tren Login.cshtml
                }
            }            
            return View(user);//return ve Login.cshtml = ko redirect di dau ca, Nhung minh muon no redirect sang man hinh khac
        }
        public ActionResult Chat()
        {
            Response.AddHeader("Refresh", "5");
            List<Chat> chats = client.GetAllChat();
            //trong view chat se chua the input, nut Send, list chat
            return View(chats);//tuong ung voi Register.cshtml
        }
        [HttpPost]
        public ActionResult Chat(string Content)
        {
            string result = client.SendChat(Content, (string)Session["UserName"]);
            return RedirectToAction("Chat", "Home");

        }
        public ActionResult Register()
        {
            return View();//tuong ung voi Register.cshtml
        }
        [HttpPost]
        public ActionResult Register(User user)
        {                        
           if (client.Register(user.UserName, user.Password).Equals("") && ModelState.IsValid)
              {
                   return RedirectToAction("Chat", "Home");//chuyen den View Chat = goi action Chat
              }           
                
            ModelState.AddModelError("LoginError", "Cannot register account");
            return View(user);//tuong ung voi Register.cshtml
        }

    }
}
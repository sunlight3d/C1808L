using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfChat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService
    {
        private DbChatEntities db = new DbChatEntities();
        bool Login(string UserName, string Password)
        {
            return db.tblUsers.Where(user => user.UserName == UserName && user.Password == Password).FirstOrDefault() != null;
        }
        string Register(string UserName, string Password)
        {
            try {
                db.tblUsers.Add(new User()
                {
                    UserName = UserName,
                    Password = Password
                });
                return UserName;
            } catch(Exception e)
            {
                return "";
            }
        }
        
        List<Chat> GetAllChat()
        {
            return db.tblChats.ToList();
        }
        
        string SendChat(string Content, string UserName)
        {
            try
            {
                if (db.tblUsers.Where(user => user.UserName == UserName).FirstOrDefault() == null)
                {
                    Console.WriteLine("Cannot find the username");
                    return "";
                }
                else {
                    db.tblChats.Add(new Chat() { 
                        Content = Content,
                        UserName = UserName,
                        SentTime = new DateTime()
                    });
                    return Content;
                }
            }
            catch (Exception e) {
                return "";
            }
        }

    }
}

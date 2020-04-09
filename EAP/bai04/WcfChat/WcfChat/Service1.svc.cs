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
    public class Service1 : IService1
    {
        private DBChatContext dbContext = new DBChatContext();
        public bool login(string UserName, string Password)
        {
            //linq
            var query = from user in dbContext.tblUsers
                        where user.UserName == UserName && user.Password == Password
                        select user;
            return query.ToList().Count > 0;
        }        
        public string Register(string UserName, string Password) //Success => "", unsuccesful => "noi dung error"
        {
            var query = from user in dbContext.tblUsers
                        where user.UserName == UserName && user.Password == Password
                        select user;
            if (query.ToList().Count > 0)
            {
                //da ton tai roi
                return "User exists";
            }
            else {
                try
                {
                    dbContext.tblUsers.Add(new User()
                    {
                        UserName = UserName,
                        Password = Password
                    });
                    //tren thuc te, password ko luu ntn, se phai ma hoa sau do moi luu vao DB
                    dbContext.SaveChanges();
                    return "";
                }
                catch (Exception e) {
                    Console.WriteLine("Error insert db: " + e.ToString());
                    return e.ToString();
                }
            }
        }
        
        public List<Chat> GetAllChat()
        {
            return dbContext.tblChats.ToList();
        }        
        public string SendChat(string Content, string Username) //ok, failed
        {
            try
            {
                //check xem username kia co ton tai ko
                //Linq query
                if(dbContext.tblUsers.Where(user => user.UserName == Username).FirstOrDefault() == null)
                {
                    return "UserName does not exist";
                }
                dbContext.tblChats.Add(new Chat()
                {
                    Content = Content,
                    UserName = Username,
                    SentTime = DateTime.Now
                });
                dbContext.SaveChanges();
                return "";
            }
            catch (Exception e) {
                return e.ToString();
            }

        }
    }
}

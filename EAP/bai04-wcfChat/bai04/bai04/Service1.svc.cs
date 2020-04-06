using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace bai04
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private ChatDb dbContext = new ChatDb();
        public bool Login(string Username, string Password)
        {
            var query = from user in dbContext.tblUsers 
                        where user.UserName == Username && user.Password == Password
                select user;
            List<User> users = query.ToList();
            return users.Count > 0;            
        }

        public string Register(string Username, string Password)
        {
            try
            {                
                dbContext.tblUsers.Add(new User()
                {
                    UserName = Username,
                    Password = Password
                });
                dbContext.SaveChanges();
                return Username;
            }
            catch (Exception e) {
                Console.WriteLine("Cannot register user. Error: " + e.ToString());
                return null;
            }
            
        }

        public List<Chat> GetAllChat()
        { 
            return dbContext
        }
    }
}

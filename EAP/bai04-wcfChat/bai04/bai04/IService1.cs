using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace bai04
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        bool Login(string Username, string Password);
        [OperationContract]
        string Register(string Username, string Password);
        [OperationContract]
        List<Chat> GetAllChat();
        
        [OperationContract]
        string SendChat(string Content, string UserName);
    }    
    
}

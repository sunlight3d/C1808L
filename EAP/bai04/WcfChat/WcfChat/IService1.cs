using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfChat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        //cac phuong thuc ma duoi client gui len
        [OperationContract]
        bool login(string UserName, string Password);

        [OperationContract]
        string Register(string UserName, string Password); //ok, failed

        [OperationContract]
        List<Chat> GetAllChat();

        [OperationContract]
        string SendChat(string Content, string Username); //ok, failed
        
        
    }

}
    
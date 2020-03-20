using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace bai01.Controllers
{
    
    public class StringProcessController: ApiController
    {
        // GET api/values
        /*
        public string Get()
        {
            return "Hello World";
        }*/
        //https://localhost:44392/api/StringProcess?name=Hoang
        public string Get(string name)
        {
            return "Helloc mr "+name;//chi de test api
        }
        //https://localhost:44392/api/StringProcess
        public DateTime Get()
        {
            return DateTime.Now;
        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
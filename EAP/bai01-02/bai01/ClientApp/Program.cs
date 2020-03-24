using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var response = await client.GetAsync("https://localhost:44392/api/EmployeesAPI");
            string responseBody = await response.Content.ReadAsStringAsync();//convert response =>string
            //Install-Package Newtonsoft.Json -Version 12.0.3
            var objects = JsonConvert.DeserializeObject<object>(responseBody);
            //https://www.newtonsoft.com/json/help/html/DeserializeObject.htm
            Console.WriteLine(response.StatusCode);
            Console.WriteLine("Hello World!");
            //Tham khao:
            //https://www.c-sharpcorner.com/article/calling-web-api-using-httpclient/

        }
    }
}

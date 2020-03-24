using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HttpClientSample
{
    public class Program
    {
        /*
        static HttpClient client = new HttpClient();
        static async Task GetAllEmployees()
        {
            var result = await client.GetAsync("https://localhost:44392/api/EmployeesAPI");
            Console.WriteLine(result.StatusCode);
        }
        */

        public static void Main(string[] args)
        {
            Console.WriteLine("hello");
        }

    }
}

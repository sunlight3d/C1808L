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
        static HttpClient client = new HttpClient();
        static void ShowEmployee(Employee employee)
        {
            Console.WriteLine($"Name: {employee.EmpName}\t");
        }
        static async Task<Uri> CreateEmployeeAsync(Employee employee)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/EmployeesAPI",employee);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            return response.Headers.Location;
        }
        static async Task<Employee> GetEmployeeAsync(string path)
        {
            Employee employee = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                employee = await response.Content.ReadAsAsync<Employee>();
            }
            return employee;
        }

        static async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/EmployeesAPI/{employee.EmpID}", employee);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated employee from the response body.
            employee = await response.Content.ReadAsAsync<Employee>();
            return employee;
        }

        static async Task<HttpStatusCode> DeleteEmployeeAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/EmployeesAPI/{id}");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("https://localhost:44392/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new employee
                Employee employee = new Employee
                {
                    EmpName = "Hoangnnn",
                    DeptID = 2,
                    Address = "nha x ngo y",
                    Email = "hoannn@gmail.com",
                };

                var url = await CreateEmployeeAsync(employee);
                Console.WriteLine($"Created at {url}");

                // Get the employee
                employee = await GetEmployeeAsync(url.PathAndQuery);
                ShowEmployee(employee);

                // Update the employee
                Console.WriteLine("Updating price...");
                employee.DeptID = 3;
                await UpdateEmployeeAsync(employee);

                // Get the updated employee
                employee = await GetEmployeeAsync(url.PathAndQuery);
                ShowEmployee(employee);

                // Delete the employee
                var statusCode = await DeleteEmployeeAsync(employee.EmpID);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        public static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

    }
}

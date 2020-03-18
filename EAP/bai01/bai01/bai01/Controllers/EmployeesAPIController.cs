using bai01.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bai01.Controllers
{
    public class EmployeesAPIController : ApiController
    {
        public IEnumerable<Employee> Get() {
            using (EmployeeDBEntities entities = new EmployeeDBEntities()) {
                entities.Configuration.ProxyCreationEnabled = false;
                //Employee employee = new Employee();                
                return entities.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                return entities.Employees.FirstOrDefault(employee => employee.EmpID == id);
            }
        }
        public void Post(Employee e)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Employees.Add(e);
                entities.SaveChanges();
            }
        }
        public void Put(Employee e)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                Employee foundEmployee = entities.Employees.FirstOrDefault(employee => employee.EmpID == e.EmpID);
                if(foundEmployee != null)
                {
                    foundEmployee = e;
                }

            }
        }
        public void Delete(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var employee = new Employee { EmpID = id };
                entities.Employees.Remove(employee);
                entities.SaveChanges();
            }
        }

    }
}

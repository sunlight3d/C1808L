using bai01.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace bai01.Controllers
{
    public class EmployeesAPIController : ApiController
    {
        public IEnumerable<Employee> Get() {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                List<Employee> employees = entities.Employees.ToList();
                var query = from employee in employees
                            select employee;
                return query.ToList();
            }
        }
        public IHttpActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                Employee foundEmployee = entities.Employees.FirstOrDefault(employee => employee.EmpID == id);
                if (foundEmployee == null)
                {
                    return NotFound();
                }
                return Ok(foundEmployee);
            }
        }
        public IHttpActionResult Post(Employee e)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                try
                {
                    entities.Employees.Add(e);
                    entities.SaveChanges();
                    return new TextResult("Insert new employee successfully", Request);
                }
                catch (Exception exception) {
                    return new TextResult("Insert new employee failed"+ exception.ToString(), Request);
                }
            }
        }
        public IHttpActionResult Put(Employee e)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                Employee foundEmployee = entities.Employees.FirstOrDefault(employee => employee.EmpID == e.EmpID);
                if(foundEmployee != null)
                {
                    foundEmployee.EmpName = e.EmpName;
                    foundEmployee.DeptID = e.DeptID;
                    foundEmployee.Address = e.Address;
                    foundEmployee.Email = e.Email;
                    foundEmployee.DOJ = e.DOJ;
                    //foundEmployee.Gender = e.Gender; ??
                    entities.SaveChanges();
                }
                else
                {
                    return NotFound();
                }                
            }
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0) 
            {
                return BadRequest("Not a valid id");
            }
                
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                Employee employee = entities.Employees.FirstOrDefault(e => e.EmpID == id);
                if(employee != null)
                {
                    entities.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
                    entities.SaveChanges();
                }
                
            }
            return Ok();
        }

    }
}

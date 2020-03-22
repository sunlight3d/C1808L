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
    //consumer: thuc chat la "Client goi web service" 
    //AJAX, fetch, ... test
    //android: okhttp
    //ios: alamofire / afnetworking....
    public class EmployeesAPIController : ApiController
    {
        //API "get all"
        //https://localhost:44392/api/EmployeesAPI
        public IEnumerable<Employee> Get() {
            //EmployeeDBEntities tham chieu den database = database context
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                List<Employee> employees = entities.Employees.ToList();//select * from Employee
                var query = from employee in employees
                            select employee;
                //LINQ trong C# => de thao tac voi List, lenh hoi giong SQL
                //trong Java cung co => goi la lambda exmpression
                return query.ToList();
            }
        }
        //api get "detail object"
        //https://localhost:44392/api/EmployeesAPI?id=6
        public IHttpActionResult Get(int id)
        {
            //IHttpActionResult tra ve response ok, failed, client co the xem duoc response
            //client check doi tuong response de quyet dinh hien thi cai gi
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
                return Ok(foundEmployee);//200 : success
            }
        }
        //https://localhost:44392/api/EmployeesAPI
        //phai dung postman
        public IHttpActionResult Post(Employee e)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                try
                {
                    entities.Employees.Add(e);
                    entities.SaveChanges(); //commit
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
                //Ket qua cua delete la "du lieu bien mat", nen employee = null cung la thanh cong
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

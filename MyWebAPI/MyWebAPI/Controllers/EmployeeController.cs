using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        Employee[] employee = new Employee[] { new Employee { ID = 1, Name = "Mark", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
         new Employee { ID = 2, Name = "Allan", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
         new Employee { ID = 3, Name = "Johny", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 21 } };


        //http://localhost:50385/api/Employee/GetAllEmployees
        [Route("api/Employee/GetAllEmployees")]
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employee;
        }

        //http://localhost:50385/api/Employee/GetEmployee?ID=1
        public IHttpActionResult GetEmployee(int ID)
        {
            var employeeRec = employee.FirstOrDefault(p => p.ID == ID);

            if (employeeRec == null)
                return NotFound();

            return Ok(employeeRec);
        }



    }
}

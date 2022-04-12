using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCGridDemo.Models;

namespace MVCGridDemo.Custom
{
    public class DepartmentAccess : IDepartmentAccess
    {
        CompanyEntities ctx;
        public DepartmentAccess()
        {
            ctx = new CompanyEntities();
        }
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns></returns>
        public List<Department> GetDepartments()
        {
            var depts = ctx.Departments.ToList();
            return depts;
        }
        /// <summary>
        /// Get Department base on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartment(int id)
        {
            var dept = ctx.Departments.Find(id);
            return dept;
        }
        /// <summary>
        /// Create Department
        /// </summary>
        /// <param name="dept"></param>
        public void CreateDepartment(Department dept)
        {
            ctx.Departments.Add(dept);
            ctx.SaveChanges();
        }
    }

}
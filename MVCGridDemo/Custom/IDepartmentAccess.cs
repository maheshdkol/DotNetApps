using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCGridDemo.Models;

namespace MVCGridDemo.Custom
{
    public interface IDepartmentAccess
    {
        List<Department> GetDepartments();
        Department GetDepartment(int id);
        void CreateDepartment(Department dept);
        //bool CheckDeptExist(int id);
    }
}
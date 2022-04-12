using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCGridDemo.Models;
using MVCGridDemo.Custom;

namespace MVCGridDemo.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentAccess objds;

        public DepartmentController()
        {
            objds = new DepartmentAccess();
        }

        // GET: Department
        public ActionResult Index()
        {
            var Depts = objds.GetDepartments();
            return View("Index", Depts);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            var Dept = new Department();
            return View(Dept);
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(Department dept)
        {
            try
            {
                objds.CreateDepartment(dept);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dept);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVCGridDemo.Controllers;
using MVCGridDemo.Models;
using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;

namespace ControllerTests
{
    //public class BaseClass
    //{
    //    [SetUp]
    //    public void BaseSetUp() { /* ... */ } // Exception thrown!

    //    [TearDown]
    //    public void BaseTearDown() { /* ... */ }
    //}

    [TestFixture]
    public class ControllerTests
    {
        DepartmentController obj;

        [SetUp]
        public void SetUp()
        {
            obj = new DepartmentController();
        }

        [Test]
        public void TestDepartmentIndex()
        {
            var actResult = obj.Index() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }

        /// <summary>
        /// Testing the RedirectToRoute to Check for the Redirect
        /// to Index Action
        /// </summary>
        [Test]
        
        public void TestDepartmentCreateRedirect()
        {
            //var obj = new DepartmentController();

            RedirectToRouteResult result = obj.Create(new Department()
            {
                DeptNo = 2,
                Dname = "D1",
                Location = "L1"
            }) as RedirectToRouteResult;


            Assert.That(result.RouteValues["action"], Is.EqualTo("Index"));

        }
    }
}

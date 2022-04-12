using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCGridDemo.Models;

namespace MVCGridDemo.Controllers
{
    public class SomeController : Controller
    {
        private MyDBEntities myDBEntities = new MyDBEntities();

        public SomeController()
        {
            //myDBEntities = 
        }

        // GET: Some
        [ActionName("Some")]
        public ActionResult Index()
        {
            Session["Message"] = "yahooooooooo";
            @ViewBag.Title = "This is first View I am trying .... !!!";
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SchemeMaster schemeMaster = new SchemeMaster();
                    schemeMaster.SchemeID = Convert.ToInt32(collection["SchemeID"]);
                    schemeMaster.SchemeName = Convert.ToString(collection["SchemeName"]);
                    myDBEntities.Entry(schemeMaster).State = System.Data.Entity.EntityState.Added;
                    myDBEntities.SaveChanges();
                }

                return RedirectToAction("Details", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
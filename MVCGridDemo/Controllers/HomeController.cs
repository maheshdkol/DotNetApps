using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCGridDemo.Models;
using MVCGridDemo.Repository;
using MVCGridDemo.Custom;
using System.Net.Http;
using System.Net;

namespace MVCGridDemo.Controllers
{
    [ActionFilterLog]
    public class HomeController : Controller
    {

        ISchemeRepository schemeRepository;
        public HomeController(ISchemeRepository repository)
        {
            schemeRepository = repository;
        }

        // GET: Home
        
        [ActionName("Index")]
        //[NonAction]

        [OutputCache(Duration = 10)]
        [AllowAnonymous]
        public ActionResult Details()
        {
            //ActionFilterLog actionFilterLog = new ActionFilterLog();
            //OnActionExecuting
            //MyDBEntities myDBEntities = new MyDBEntities();
            //var SchemeList = (from scheme in myDBEntities.SchemeMasters select scheme).ToList();
            var SchemeList = schemeRepository.GetAll();
            return View(SchemeList);
        }

        [Route("Home/StringReturn/{PassedString}")]
        public string StringReturn(string PassedString)
        {
            return PassedString;
        }

        // https://localhost:44328/Home/SchemeDetails?SchemeId=1
        // https://www.tutorialsteacher.com/webapi/consume-web-api-get-method-in-aspnet-mvc
        public ActionResult SchemeDetails(int SchemeId)
        {
            var schemeMaster = schemeRepository.GetScheme(SchemeId);
            return View(schemeMaster);
        }

        //https://localhost:44328/Home/GetAllEmployeesFrmExternalAPI

        [HttpGet]
        public JsonResult GetAllEmployeesFrmExternalAPI()
        {
            //IEnumerable<object> Users = null;
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://dummy.restapiexample.com/api/v1/employees");

            //    var responseTask = client.GetAsync("page");
            //    responseTask.Wait();
            //    var result = responseTask.Result;
            //}
            //return View(Users);

            //Fetch the JSON string from URL.
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = (new WebClient()).DownloadString("http://dummy.restapiexample.com/api/v1/employees");

            //Return the JSON string.
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
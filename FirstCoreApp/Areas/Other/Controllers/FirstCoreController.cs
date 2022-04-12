using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FirstCoreApp.Controllers
{
    [Area("Other")]
    public class FirstCoreController : Controller
    {
        // https://localhost:44308/Other/FirstCore/FirstCore

        public IActionResult FirstCore()
        {
            ViewBag.Header = "Hello ... .This is my first Core View !!!";
            HttpContext.Session.SetString("FirstSessionvar", "Popped up from session variable...");
            return View();
        }
    }
}
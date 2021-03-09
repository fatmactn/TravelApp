using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelApp.Models.Classes;

namespace travelApp.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Abouts.ToList();
            return View(values);
        }
    }
}
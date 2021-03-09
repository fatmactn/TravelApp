using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using travelApp.Models.Classes;

namespace travelApp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }

        public ActionResult About()
        {
            return View();
        }

        public PartialViewResult PartialRecentPlaces()
        {
            var values = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialRecentPlacesRight()
        {
            var value = c.Blogs.Where(x => x.ID == 3).ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialTopPlaces()
        {
            var value = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialBestPlaces()
        {
            var value = c.Blogs.Take(3).ToList();
            return PartialView(value);
        }

        public PartialViewResult PartialBestPlacesRight()
        {
            var value = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(value);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelApp.Models.Classes;
using travelApp.Controllers;

namespace travelApp.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        public ActionResult Index()
        {
            bc.Value1 = c.Blogs.ToList();
            bc.Value3 = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            //var blogs = c.Blogs.ToList();
            return View(bc);
        }
        BlogComment bc = new BlogComment();
        public ActionResult BlogDetail(int id)
        {
            bc.Value1 = c.Blogs.Where(x => x.ID == id).ToList();
            bc.Value2 = c.Comments.Where(x => x.BlogId == id).ToList();
            //var findblog = c.Blogs.Where(x => x.ID == id).ToList();
            return View(bc);
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.value = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddComment(Comment comm)
        {
            c.Comments.Add(comm);
            c.SaveChanges();
            return PartialView();
        }
    }
}
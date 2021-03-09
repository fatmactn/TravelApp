using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using travelApp.Models.Classes;

namespace travelApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringBlog(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BringBlog", bl);
        }

        public ActionResult UpdateBlog(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Title = b.Title;
            blg.Date = b.Date;
            blg.BlogImg = b.BlogImg;
            blg.Content = b.Content;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CommentList()
        {
            var comments = c.Comments.ToList();
            return View(comments);
        }

        public ActionResult DeleteComment(int id)
        {
            var b = c.Comments.Find(id);
            c.Comments.Remove(b);
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }

        public ActionResult BringComment(int id)
        {
            var cm = c.Comments.Find(id);
            return View("BringComment", cm);
        }

        public ActionResult UpdateComment(Comment co)
        {
            var com = c.Comments.Find(co.ID);
            com.UserName = co.UserName;
            com.Mail = co.Mail;
            com.Content = co.Content;
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }
    }
}
using FA.JustBlog.Models;
using FA.JustBlog.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public class TagController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private TagRepository tp = new TagRepository();

        // GET: Tag
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly] 
        public ActionResult PopularTags() 
        { 
            return PartialView("_PopularTags", tp.GetAllTags()); 
        }

        //GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag = db.Tags.Find(id);
            if (tag == null)
            {
                return HttpNotFound();
            }
            return View(tag);
        }
    }
}
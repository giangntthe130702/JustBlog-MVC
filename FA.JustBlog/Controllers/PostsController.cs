using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models;
using FA.JustBlog.Repositories;

namespace FA.JustBlog.Controllers
{
    public class PostsController : Controller
    {
        private JustBlogContext db = new JustBlogContext();
        private PostRepository pr = new PostRepository();

        // GET: Posts
        public ActionResult Index()
        {
            return View(pr.GetAllPosts());
        }

        //GET: Posts/LastestPost
        public ActionResult LatestPost()
        {
            return View(pr.GetLatestPost(pr.GetAllPosts().Count));
        }
        public ActionResult Details(int year, int month, string title)
        {
            var post = pr.FindPost(year, month, title);
            if (post == null)
                return HttpNotFound();
            return View(post);
        }

        
        //GET: Post/MostViewPost
        public ActionResult MostViewedPosts()
        {
            //return View("_ListPosts");
            return PartialView("_ListPosts", pr.GetMostViewedPost(pr.GetAllPosts().Count));        
        }

        public ActionResult LatestPostsinside()
        {
            //return View("_ListPosts");
            return PartialView("_ListPosts", pr.GetLatestPost(pr.GetAllPosts().Count));
        }

        

        ////GET: Posts/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Post post = db.Posts.Find(id);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(post);
        //}

        //// GET: Posts/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
        //    return View();
        //}

        //// POST: Posts/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Title,Description,PostContent,UrlSlug,Published,PostOn,Modified,CategoryId,ViewCount,RateCount,TotalRate,Rate")] Post post)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Posts.Add(post);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
        //    return View(post);
        //}

        //// GET: Posts/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Post post = db.Posts.Find(id);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
        //    return View(post);
        //}

        //// POST: Posts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title,Description,PostContent,UrlSlug,Published,PostOn,Modified,CategoryId,ViewCount,RateCount,TotalRate,Rate")] Post post)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(post).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", post.CategoryId);
        //    return View(post);
        //}

        //// GET: Posts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Post post = db.Posts.Find(id);
        //    if (post == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(post);
        //}

        //// POST: Posts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Post post = db.Posts.Find(id);
        //    db.Posts.Remove(post);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}

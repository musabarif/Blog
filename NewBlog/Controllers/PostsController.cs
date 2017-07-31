using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewBlog.Models;

namespace NewBlog.Controllers
{
    public class PostsController : Controller
    {
        private NewBlogDBContext db = new NewBlogDBContext();
        const string PostAddModelKey = "_post_model";
        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.Include(X => X.Tags).Include(x => x.AuthorName));
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = db.Posts.Where(x => x.ID == id).Include(X => X.Tags).Include(x=>x.AuthorName).FirstOrDefault();

            post.Views = post.Views + 1;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        public ActionResult AddTag(Post model)
        {
            if (model.Tags == null)
            {
                model.Tags = new List<Tags>();
            }

            model.Tags.Add(new Tags() { Name = "", TagID = 0 });
            TempData[PostAddModelKey] = model;
            return RedirectToAction("Create");
        }

      

        // GET: Posts/Create
        public ActionResult Create()
        {
            Post _model = null;
            if (TempData.ContainsKey(PostAddModelKey))
            {
                _model = TempData[PostAddModelKey] as Post;
            }
            else
            {
                _model = new Post();
            }
            //_model.VideoTypes = EnumOperations.ToList<Data.Video.Types>().Select(kV => new SelectListItem() { Value = kV.Value, Text = kV.Key }).ToList();
            return View(_model);


        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Where(x => x.ID == id).Include(X => X.Tags).Include(y=>y.AuthorName).FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Text,Date,AuthorName,Tags")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Where(x => x.ID == id).Include(X => X.Tags).Include(x => x.AuthorName).FirstOrDefault();
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Where(x => x.ID == id).Include(X => X.Tags).Include(x => x.AuthorName).FirstOrDefault();
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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

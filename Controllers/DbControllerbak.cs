using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UpmessageMVCNETCore.Models;
using UpmessageMVCNETCore.Model;

namespace UpmessageMVCNETCore
{
    /*
    public class DbController : Controller
    {
        private HatunWillanaContext db = new HatunWillanaContext();

        // GET: Db     
        public ActionResult Index()
        {
            using (var db = new HatunWillanaContext())
            {

                var posts = db.Posts
                            .Where(e => e.ParentId == null)
                            .Select(e => new PostBL
                            {
                                PostID = e.PostId,
                                Title = e.Title,
                                Body = e.Body,
                                UserID = e.UserId,
                                DateCreated = e.DateCreated,
                                ParentID = e.ParentId,
                            });
                List<PostBL> postsbl = posts.ToList();

                List<PostBL> postsall = db.Posts
                            .Select(e => new PostBL
                            {
                                PostID = e.PostId,
                                Title = e.Title,
                                Body = e.Body,
                                UserID = e.UserId,
                                DateCreated = e.DateCreated,
                                ParentID = e.ParentId,
                            }).ToList();

                List<PostBL> postsc = new List<PostBL>();

                foreach (PostBL a in postsbl)
                {
                    PostBL newbl = new PostBL() { Body = a.Body, DateCreated = a.DateCreated, PostID = a.PostID, Title = a.Title, UserID = a.UserID, ParentID = a.ParentID, Children = GetChildren(postsall, a.PostID) };
                    postsc.Add(newbl);
                }

                return View(postsc);
            }

        }

        private List<PostBL> GetChildren(List<PostBL> items, long parentid)
        {
            return items
            .Where(e => e.ParentID == parentid)
            .Select(e => new PostBL
            {
                PostID = e.PostID,
                Title = e.Title,
                Body = e.Body,
                UserID = e.UserID,
                DateCreated = e.DateCreated,
                ParentID = e.ParentID,
                Children = GetChildren(items, e.PostID)
            }).ToList();
        }
        /*
        // GET: Db/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Db/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Db/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,Body,UserID,DateCreated,ParentID,DiscussionID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Db/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Db/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Title,Body,UserID,DateCreated,ParentID,DiscussionID")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Db/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Db/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Post post = db.Posts.Find(id);
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
    */
}
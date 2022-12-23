using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UpmessageMVCNETCore.Models;
using UpmessageMVCNETCore.Model;
using Newtonsoft.Json;

namespace UpmessageMVCNETCore
{
    public class DbController : Controller
    {

        private static HatunWillanaContext db;
        private static DbContextOptionsBuilder ob = new DbContextOptionsBuilder<HatunWillanaContext>();
        private PostDBAccessLayer al = new PostDBAccessLayer();
        
        private static IConfigurationRoot configuration = (IConfigurationRoot)new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        private static string connString = "Server=ACER-SMALL;Database=HatunWillana;Trusted_Connection=True;";
        // GET: Db     
        public ActionResult Index()
        {

                List<PostBL> posts;
                posts = GetPosts();
                return View(posts);
            
        }


        private List<PostBL> GetPosts()
        {

            //ob.UseSqlServer(connString);
            ob.UseSqlServer(configuration.GetConnectionString("Connection1"));
            using (db = new HatunWillanaContext((DbContextOptions<HatunWillanaContext>)ob.Options))
            {


                //  Get Thread-level posts
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
                /*
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
                */
                List<PostBL> postsc = new List<PostBL>();


                //  Get children for each Thread-level post
                foreach (PostBL a in postsbl)
                {
                    PostBL newbl = new PostBL() { Body = a.Body, DateCreated = a.DateCreated, PostID = a.PostID, Title = a.Title, UserID = a.UserID, ParentID = a.ParentID, Children = GetChildren(a.PostID) };
                    postsc.Add(newbl);
                }

                return postsc;
            }
        }

        [HttpPost]
        public ActionResult Index(Post post)
        {
            ob.UseSqlServer(configuration.GetConnectionString("Connection1"));
            if(ModelState.IsValid)
            {
                bool  isCaptchaValid = IsCaptchaValid(post.GoogleCaptchaToken).Result; 
                if  (isCaptchaValid) { 
                    string resp = al.AddPostRecord(post);
                }
            }

            List<PostBL> posts;
            posts = GetPosts();
            ModelState.Clear();
            return View(posts);
        }

        private async Task<bool> IsCaptchaValid(string response)
        {
            try {
                var secret = "6LdlUOUhAAAAAA0zV3tD1tQ82IrQktj-eP0iAk-k";
                    using (var client = new     HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                            {"secret", secret},
                            { "response", response},
                            { "remoteip", HttpContext.Connection.RemoteIpAddress.ToString() }
                    };
                    var content = new FormUrlEncodedContent(values);
                    var verify = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                    var captchaResponseJson = await verify.Content.ReadAsStringAsync();
                    var captchaResult = JsonConvert.DeserializeObject<CaptchaResponseViewModel>(captchaResponseJson);
                    return captchaResult.Success
                        && captchaResult.Action == "Index"
                        && captchaResult.Score > 0.5;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static List<PostBL> GetChildren(long parentid)
        {             ob.UseSqlServer(configuration.GetConnectionString("Connection1"));
            //ob.UseSqlServer(connString);

 //           using (db = new HatunWillanaContext((DbContextOptions<HatunWillanaContext>)ob.Options))
 //           {
                var posts = db.Posts
                        .Where(e => e.ParentId == parentid)
                        .Select(e => new PostBL
                        {
                            PostID = e.PostId,
                            Title = e.Title,
                            Body = e.Body,
                            UserID = e.UserId,
                            DateCreated = e.DateCreated,
                            ParentID = e.ParentId,
                            Children = GetChildren(e.PostId)
                        });
                List<PostBL> postsbl = posts.ToList();

                return postsbl;
   //         }
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
        */
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Melissa_Scott_9189_SA2_IPG521_Final.Models;
using Microsoft.AspNet.Identity;

namespace Melissa_Scott_9189_SA2_IPG521_Final.Controllers
{
    public class AuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Authors
        [Authorize(Roles = "Author")]
        public ActionResult Index()
        {

            var user = User.Identity.GetUserName();
            //return View(db.Authors.Where(x => x.PaperAuthor == user).ToList());
            return View(db.Authors.Where(x => x.PaperAuthor == user).Include(a => a.Topics).ToList());
        }
        public ActionResult Papers()
        {
            return View(db.Authors.Include(a => a.Topics).ToList());
        }


        // GET: Authors/Details/5
        [Authorize(Roles = "Author")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        [Authorize(Roles = "Author")]
        public ActionResult Create()
        {
            ViewBag.PaperTopicIdId = new SelectList(db.Topics, "PaperTopicIdId", "TopicName");
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperTopicIdId")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                TempData["Message"] = "Paper sucessfully submitted.";
                return RedirectToAction("Index");
            }
            ViewBag.PaperTopicIdId = new SelectList(db.Topics, "PaperTopicIdId", "TopicName", author.PaperTopicIdId);
            return View(author);
        }

        // GET: Authors/Edit/5
        [Authorize(Roles = "Author")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            ViewBag.PaperTopicIdId = new SelectList(db.Topics, "PaperTopicIdId", "TopicName", author.PaperTopicIdId);
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit([Bind(Include = "PaperId,PaperTitle,PaperAbstract,PaperAuthor,PaperTopicIdId")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Message"] = "Paper sucessfully updated.";
                return RedirectToAction("Index");
            }
            ViewBag.PaperTopicIdId = new SelectList(db.Topics, "PaperTopicIdId", "TopicName", author.PaperTopicIdId);
            return View(author);
        }

        // GET: Authors/Delete/5
        [Authorize(Roles = "Author")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            TempData["Message"] = "Paper sucessfully Deleted.";
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

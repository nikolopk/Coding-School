using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CF.Data.Context;
using CF.Models.Database;

namespace WebApplication1.Controllers
{
    public class UserProjectCommentsController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();

        // GET: UserProjectComments
        public async Task<ActionResult> Index()
        {
            var userProjectComments = db.UserProjectComments.Include(u => u.Project).Include(u => u.User);
            return View(await userProjectComments.ToListAsync());
        }

        // GET: UserProjectComments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjectComment userProjectComment = await db.UserProjectComments.FindAsync(id);
            if (userProjectComment == null)
            {
                return HttpNotFound();
            }
            return View(userProjectComment);
        }

        [Authorize]
        // GET: UserProjectComments/Create
        public ActionResult Create(int? projectId)
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title");
            // ViewBag.BackerId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: UserProjectComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,BackerId,ProjectId,Text,DateInserted")] UserProjectComment userProjectComment)
        {
            if (ModelState.IsValid)
            {
                db.UserProjectComments.Add(userProjectComment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", userProjectComment.ProjectId);
            ViewBag.BackerId = new SelectList(db.Users, "Id", "Email", userProjectComment.BackerId);
            return View(userProjectComment);
        }

        // GET: UserProjectComments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjectComment userProjectComment = await db.UserProjectComments.FindAsync(id);
            if (userProjectComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", userProjectComment.ProjectId);
            ViewBag.BackerId = new SelectList(db.Users, "Id", "Email", userProjectComment.BackerId);
            return View(userProjectComment);
        }

        // POST: UserProjectComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,BackerId,ProjectId,Text,DateInserted")] UserProjectComment userProjectComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProjectComment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", userProjectComment.ProjectId);
            ViewBag.BackerId = new SelectList(db.Users, "Id", "Email", userProjectComment.BackerId);
            return View(userProjectComment);
        }

        // GET: UserProjectComments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProjectComment userProjectComment = await db.UserProjectComments.FindAsync(id);
            if (userProjectComment == null)
            {
                return HttpNotFound();
            }
            return View(userProjectComment);
        }

        // POST: UserProjectComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserProjectComment userProjectComment = await db.UserProjectComments.FindAsync(id);
            db.UserProjectComments.Remove(userProjectComment);
            await db.SaveChangesAsync();
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

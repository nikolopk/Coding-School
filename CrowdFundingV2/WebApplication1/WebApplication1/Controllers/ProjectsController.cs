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
    public class ProjectsController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();

        // GET: Projects
        public async Task<ActionResult> Index()
        {
            var projects = db.Projects.Include(p => p.Category).Include(p => p.ProjectStatu).Include(p => p.User);
            return View(await projects.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name");
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "PhotoUrl");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CreatorId,Title,Description,StatusId,CategoryId,DueDate,TargetAmount,CurrentFundAmount,Ratio,DateInserted,DateVerified,VerificationGuid")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "PhotoUrl", project.CreatorId);
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "PhotoUrl", project.CreatorId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CreatorId,Title,Description,StatusId,CategoryId,DueDate,TargetAmount,CurrentFundAmount,Ratio,DateInserted,DateVerified,VerificationGuid")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "PhotoUrl", project.CreatorId);
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = await db.Projects.FindAsync(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Project project = await db.Projects.FindAsync(id);
            db.Projects.Remove(project);
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

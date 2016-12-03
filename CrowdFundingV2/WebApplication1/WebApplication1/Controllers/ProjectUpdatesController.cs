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
using WebApplication1.Models;
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class ProjectUpdatesController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();
        private readonly ApplicationUserManager _userManager;

        public ProjectUpdatesController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: ProjectUpdates
        public async Task<ActionResult> Index()
        {
            var projectUpdates = db.ProjectUpdates.Include(p => p.Project);
            return View(await projectUpdates.ToListAsync());
        }

        // GET: ProjectUpdates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectUpdate projectUpdate = await db.ProjectUpdates.FindAsync(id);
            if (projectUpdate == null)
            {
                return HttpNotFound();
            }
            return View(projectUpdate);
        }

        // GET: ProjectUpdates/Create
        [Authorize]
        public ActionResult Create(int? projectId)
        {
            if (projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new ProjectUpdateViewModel()
            {
                ProjectId = projectId.Value
            };
            return View(viewModel);
        }

        // POST: ProjectUpdates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create(ProjectUpdateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindById(User.Identity.GetUserId());
                var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();

                var update = new ProjectUpdate()
                {
                    ProjectId=viewModel.ProjectId,
                    Text = viewModel.Text,
                    DateInserted = DateTime.Now
                };
                db.ProjectUpdates.Add(update);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "Project", new { id = viewModel.ProjectId });
            }
            
            return View(viewModel);
        }

        // GET: ProjectUpdates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectUpdate projectUpdate = await db.ProjectUpdates.FindAsync(id);
            if (projectUpdate == null)
            {
                return HttpNotFound();
            }
            return View(projectUpdate);
        }

        // POST: ProjectUpdates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,Text,DateInserted")] ProjectUpdate projectUpdate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectUpdate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", projectUpdate.ProjectId);
            return View(projectUpdate);
        }

        // GET: ProjectUpdates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectUpdate projectUpdate = await db.ProjectUpdates.FindAsync(id);
            if (projectUpdate == null)
            {
                return HttpNotFound();
            }
            return View(projectUpdate);
        }

        // POST: ProjectUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProjectUpdate projectUpdate = await db.ProjectUpdates.FindAsync(id);
            db.ProjectUpdates.Remove(projectUpdate);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CF.Data.Context;
using CF.Models.Database;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProjectsController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();
        private readonly ApplicationUserManager _userManager;
        
        public ProjectsController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: Projects
        public async Task<ActionResult> Index()
        {
            var projects = db.Projects.Include(p => p.Category).Include(p => p.ProjectStatu).Include(p => p.User);
            return View(await projects.ToListAsync());
        }


        [HttpGet]
        public ActionResult Create()
        {
            var model = new ProjectViewModel()
            {
                Categories = db.Categories.ToList(),
                Statuses = db.ProjectStatus.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Status(ProjectViewModel model)
        {
            return new EmptyResult();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(ProjectViewModel project)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();
            var dbProject = new Project()
            {
                CategoryId = project.SelectedCategoryId,
                CreatorId=myUser.Id,
                DateInserted=DateTime.Now,
                CurrentFundAmount = project.Project.CurrentFundAmount,
                Description = project.Project.Description,
                Ratio = project.Project.Ratio,
                StatusId = project.Project.StatusId,
                DueDate = project.Project.DueDate,
                TargetAmount = project.Project.TargetAmount,
                Title = project.Project.Title
                
            };

            //project.CreatorId = myUser.Id;
            //project.StatusId = 1;
            //project.DateInserted = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Projects.Add(dbProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var viewModel = new Models.ProjectViewModel()
            {

                Categories = db.Categories.ToList(),
                Statuses = db.ProjectStatus.ToList(),
                Project = dbProject
            };
            

            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            //ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);

            return View(viewModel);
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

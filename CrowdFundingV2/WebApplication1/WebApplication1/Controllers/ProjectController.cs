using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;

using Microsoft.AspNet.Identity;
using CF.Models.Database;
using System.Net;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ProjectController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();
        private readonly ApplicationUserManager _userManager;


        public ProjectController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }
        
        // GET: Test
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Category).Include(p => p.ProjectStatu).Include(p => p.User);
            return View(projects.ToList());
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();

            var model = new ProjectViewModel()
            {
                Categories = db.Categories.ToList(),
                Statuses = db.ProjectStatus.ToList(),
                CreatorFullName = user.FirstName + " " + user.LastName,
                CreatorId = myUser.Id,
                NoProjects = db.Projects.Where(x =>x.CreatorId == myUser.Id).Count()
            };

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreatorProjects(int id)
        {
            var projects = db.Projects.Where(x => x.CreatorId == id).ToList();

            return View(projects);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ProjectViewModel model)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();
            var dbProject = new Project()
            {
                CategoryId = model.SelectedCategoryId,
                CreatorId = myUser.Id,
                DateInserted = DateTime.Now,
                CurrentFundAmount = model.Project.CurrentFundAmount,
                Description = model.Project.Description,
                Ratio = model.Project.Ratio,
                StatusId = 1,
                DueDate = model.Project.DueDate,
                TargetAmount = model.Project.TargetAmount,
                Title = model.Project.Title

            };

            //project.CreatorId = myUser.Id;
            //project.StatusId = 1;
            //project.DateInserted = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Projects.Add(dbProject);
                db.SaveChanges();
                return RedirectToAction("Edit", dbProject.Id);
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
            var user = _userManager.FindById(User.Identity.GetUserId());
            var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();
            if (project.CreatorId != myUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);

            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Edit([Bind(Include = "Id,CreatorId,Title,Description,StatusId,CategoryId,DueDate,TargetAmount,CurrentFundAmount,Ratio,DateInserted,DateVerified,VerificationGuid")] Project project)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();
            if (project.CreatorId != myUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);
            ViewBag.CreatorId = new SelectList(db.Users, "Id", "PhotoUrl", project.CreatorId);
            return View(project);
        }

    }
}
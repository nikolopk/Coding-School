using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data;
using System.Data.Entity;

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
            var project = db.Projects
                           .Include(p => p.User)
                           .Include(p => p.BackerProjects)
                           .Include(p => p.UserProjectComments)
                           .Select(y => new BasicProjectInfoViewModel()
                           {
                               Id = y.Id,
                               Title = y.Title,
                               CreatorFullName = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.FirstName,
                               Description = y.Description,
                               CurrentFund = y.CurrentFundAmount,
                               Ratio = (int)Math.Floor((y.Ratio * 100)),
                               CurrentBackerCount = y.BackerProjects.Where(x => x.ProjectId == y.Id).Count(),
                               DueDate = y.DueDate,
                               NoComments = y.UserProjectComments.Where(x => x.ProjectId == y.Id).Count(),
                           }).FirstOrDefault();
            return View(project);
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
                NoProjects = db.Projects.Where(x =>x.CreatorId == myUser.Id).Count(),
                MyProjects = CreatorProjects(myUser.Id)
            };

            return View(model);
        }

        public async Task<ActionResult> ProjectByCreator(int id)
        {
            var projects = db.Projects
                           .Include(p => p.User)
                           .Include(p => p.BackerProjects)
                           .Include(p => p.UserProjectComments)
                           .Where(x => x.CreatorId == id)
                           .Select(y => new BasicProjectInfoViewModel()
                           {
                               Id = y.Id,
                               Title = y.Title,
                               CreatorFullName = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.FirstName,
                               Description = y.Description,
                               CurrentFund = y.CurrentFundAmount,
                               Ratio = (int)Math.Floor((y.Ratio * 100)),
                               CurrentBackerCount = y.BackerProjects.Where(x => x.ProjectId == y.Id).Count(),
                               DueDate = y.DueDate,
                               NoComments = y.UserProjectComments.Where(x => x.ProjectId == y.Id).Count(),
                           });



            return View(await projects.ToListAsync());
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<BasicProjectInfoViewModel> CreatorProjects(int id)
        {
            var projects = db.Projects
                           .Include(p => p.User)
                           .Include(p => p.BackerProjects)
                           .Include(p => p.UserProjectComments)
                           .Where(x => x.CreatorId == id)
                           .Select(y => new BasicProjectInfoViewModel()
                                    {
                                        Id = y.Id,
                                        Title = y.Title,
                                        CreatorFullName = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.FirstName,
                                        Description = y.Description,
                                        CurrentFund = y.CurrentFundAmount,
                                        Ratio = (int)Math.Floor((y.Ratio * 100)),
                                        CurrentBackerCount = y.BackerProjects.Where(x=>x.ProjectId == y.Id).Count(),
                                        DueDate = y.DueDate,
                                        NoComments = y.UserProjectComments.Where(x => x.ProjectId == y.Id).Count(),
                                    }).ToList();

            

            return projects;
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
                Project = dbProject,
                MyProjects = CreatorProjects(myUser.Id)
            };


            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            //ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);

            return View(viewModel);
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

            var user = project.User;
            var aspNetUser = user.AspNetUser;
            var viewModel = new ProjectDetailsViewModel()
            {
                CreatorId = user.Id,
                Title = project.Title,
                Description = project.Description,
                DueDate = project.DueDate,
                Ratio = (int)Math.Floor(project.Ratio * 100),
                TargetAmount = project.TargetAmount,
                CreatorNoProjects = user.Projects.Count(),
                CurrentFund = project.CurrentFundAmount,
                CreatorFullName = aspNetUser.FirstName + " " + aspNetUser.LastName,
                CurrentBackerCount = project.BackerProjects.Count(),
                DateInserted = project.DateInserted,
                Id = project.Id,
                Comments = project.UserProjectComments.Select(c => new ProjectCommentViewModel()
                {
                    CommentorFullName = c.User.AspNetUser.FirstName + " " + c.User.AspNetUser.LastName,
                    DateInserted = c.DateInserted,
                    Text = c.Text
                }).ToList(),
                Updates = project.ProjectUpdates.Select(u => new ProjectUpdateViewModel()
                {
                    FullName = aspNetUser.FirstName + " " + aspNetUser.LastName,
                    DateInserted = u.DateInserted,
                    Text = u.Text
                }).ToList(),
                Backers = project.BackerProjects.Select(b => new BackerViewModel()
                {
                    FullName = b.User.AspNetUser.FirstName + " " + b.User.AspNetUser.LastName,
                    NoProjects = b.User.BackerProjects.Count()
                }).ToList()
            };
            return View(viewModel);
        }

    }
}
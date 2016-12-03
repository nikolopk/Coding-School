using CF.Data.Context;
using CF.Models.Database;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
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
                               Id                 = y.Id,
                               Title              = y.Title,
                               CreatorFullName    = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.FirstName,
                               Description        = y.Description,
                               CurrentFund        = y.CurrentFundAmount,
                               Ratio              = (int)Math.Floor((y.Ratio * 100)),
                               CurrentBackerCount = y.BackerProjects.Where(x => x.ProjectId == y.Id).Count(),
                               DueDate            = y.DueDate,
                               NoComments         = y.UserProjectComments.Where(x => x.ProjectId == y.Id).Count(),
                           }).FirstOrDefault();
            return View(project);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var user   = _userManager.FindById(User.Identity.GetUserId());
            var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();


            var model = new ProjectViewModel()
            {
                Categories      = db.Categories.ToList(),
                Statuses        = db.ProjectStatus.ToList(),
                CreatorFullName = user.FirstName + " " + user.LastName,
                CreatorId       = myUser.Id,
                NoProjects      = db.Projects.Where(x =>x.CreatorId == myUser.Id).Count(),
                MyProjects      = CreatorProjects(myUser.Id)
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
                               Id                 = y.Id,
                               Title              = y.Title,
                               CreatorFullName    = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.FirstName,
                               Description        = y.Description,
                               CurrentFund        = y.CurrentFundAmount,
                               Ratio              = (int)Math.Floor((y.Ratio * 100)),
                               CurrentBackerCount = y.BackerProjects.Where(x => x.ProjectId == y.Id).Count(),
                               DueDate            = y.DueDate,
                               NoComments         = y.UserProjectComments.Where(x => x.ProjectId == y.Id).Count(),
                           });



            return View(await projects.ToListAsync());
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<BasicProjectInfoViewModel> CreatorProjects(int id)
        {
            var projects  = db.Projects
                           .Include(p => p.User)
                           .Include(p => p.BackerProjects)
                           .Include(p => p.UserProjectComments)
                           .Where(x   => x.CreatorId == id)
                           .Select(y  => new BasicProjectInfoViewModel()
                                    {
                                        Id                 = y.Id,
                                        Title              = y.Title,
                                        CreatorFullName    = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.FirstName,
                                        Description        = y.Description,
                                        CurrentFund        = y.CurrentFundAmount,
                                        Ratio              = (int)Math.Floor((y.Ratio * 100)),
                                        CurrentBackerCount = y.BackerProjects.Where(x=>x.ProjectId == y.Id).Count(),
                                        DueDate            = y.DueDate,
                                        NoComments         = y.UserProjectComments.Where(x => x.ProjectId == y.Id).Count(),
                                    }).ToList();

            

            return projects;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(ProjectViewModel model)
        {
            var user      = _userManager.FindById(User.Identity.GetUserId());
            var myUser    = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();
            var dbProject = new Project()
            {
                CategoryId        = model.SelectedCategoryId,
                CreatorId         = myUser.Id,
                DateInserted      = DateTime.Now,
                CurrentFundAmount = model.Project.CurrentFundAmount,
                Description       = model.Project.Description,
                Ratio             = model.Project.Ratio,
                StatusId          = 1,
                DueDate           = model.Project.DueDate,
                TargetAmount      = model.Project.TargetAmount,
                Title             = model.Project.Title

            };

            //project.CreatorId = myUser.Id;
            //project.StatusId = 1;
            //project.DateInserted = DateTime.Now;

            if (ModelState.IsValid)
            {
                dbProject = db.Projects.Add(dbProject);
                db.SaveChanges();
                return RedirectToAction("Edit", new { id = dbProject.Id }); 
            }
            var viewModel = new Models.ProjectViewModel()
            {

                Categories = db.Categories.ToList(),
                Statuses   = db.ProjectStatus.ToList(),
                Project    = dbProject,
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

            var user       = project.User;
            var aspNetUser = user.AspNetUser;
            var viewModel  = new ProjectDetailsViewModel()
            {
                CreatorId          = user.Id,
                Title              = project.Title,
                Description        = project.Description,
                DueDate            = project.DueDate,
                Ratio              = (int)Math.Floor(project.Ratio * 100),
                TargetAmount       = project.TargetAmount,
                CreatorNoProjects  = user.Projects.Count(),
                CurrentFund        = project.CurrentFundAmount,
                CreatorFullName    = aspNetUser.FirstName + " " + aspNetUser.LastName,
                CurrentBackerCount = project.BackerProjects.Count(),
                DateInserted       = project.DateInserted,
                Id                 = project.Id,
                Comments           = project.UserProjectComments.Select(c => new ProjectCommentViewModel()
                {
                    CommentorFullName = c.User.AspNetUser.FirstName + " " + c.User.AspNetUser.LastName,
                    DateInserted      = c.DateInserted,
                    Text              = c.Text
                }).ToList(),
                Updates = project.ProjectUpdates.Select(u => new ProjectUpdateViewModel()
                {
                    FullName     = aspNetUser.FirstName + " " + aspNetUser.LastName,
                    DateInserted = u.DateInserted,
                    Text         = u.Text
                }).ToList(),
                Backers = project.BackerProjects.Select(b => new BackerViewModel()
                {
                    FullName   = b.User.AspNetUser.FirstName + " " + b.User.AspNetUser.LastName,
                    NoProjects = b.User.BackerProjects.Count()
                }).ToList(),
                Rewards = project.Rewards.Select(r => new RewardViewModel()
                {
                    Id               = project.Id,
                    ProjectId        = project.Id,
                    CurrentAvailable = r.CurrentAvailable,
                    Description      = r.Description,
                    MaxAvailable     = r.MaxAvailable,
                    MaxAmount        = r.MaxRequiredAmount,
                    MinAmount        = r.MinRequiredAmount,
                    Title            = r.Name
                }
                ).ToList()
            };
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
            var user               = _userManager.FindById(User.Identity.GetUserId());
            var myUser             = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();
            if (project.CreatorId != myUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new ProjectEditViewModel()
            {
                Id                 = project.Id,
                Categories         = db.Categories.ToList(),
                Statuses           = db.ProjectStatus.ToList(),
                CreatorFullName    = user.FirstName + " " + user.LastName,
                CreatorId          = myUser.Id,
                SelectedCategoryId = project.CategoryId,
                SelectedStatusId   = project.StatusId,
                NoProjects         = db.Projects.Where(x => x.CreatorId == myUser.Id).Count(),
                MyProjects         = CreatorProjects(myUser.Id),
                Project            = project,
                Comments           = db.UserProjectComments.Where(x => x.ProjectId == project.Id).Select(y => new ProjectCommentViewModel()
                {
                    CommentorFullName = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.LastName,
                    DateInserted      = y.DateInserted,
                    Text              = y.Text
                }).ToList(),
                Updates = db.ProjectUpdates.Where(x => x.ProjectId == project.Id).Select(y => new ProjectUpdateViewModel()
                {
                    FullName     = user.FirstName + " " + user.LastName,
                    DateInserted = y.DateInserted,
                    Text         = y.Text
                }).ToList(),
                Rewards = db.Rewards.Where(x => x.ProjectId == project.Id).Select(y => new RewardViewModel()
                {
                    Title            = y.Name,
                    ProjectId        = project.Id,
                    CurrentAvailable = y.CurrentAvailable,
                    Description      = y.Description,
                    MaxAvailable     = y.MaxAvailable
                }).ToList()
            };

            return View(model);

            //ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", project.CategoryId);
            //ViewBag.StatusId = new SelectList(db.ProjectStatus, "Id", "Name", project.StatusId);

            //return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProjectEditViewModel viewModel)
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();
            if (viewModel.Project.CreatorId != myUser.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                var project          = db.Projects.Find(viewModel.Project.Id);
                project.DueDate      = viewModel.Project.DueDate;
                project.Description  = viewModel.Project.Description;
                project.TargetAmount = viewModel.Project.TargetAmount;
                project.Ratio        = (project.CurrentFundAmount / viewModel.Project.TargetAmount);
                project.Title        = viewModel.Project.Title;
                project.CategoryId   = viewModel.SelectedCategoryId;
                project.StatusId     = viewModel.SelectedStatusId;

                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }


        //POST : API/id
        [HttpPost]
        public ActionResult BuckProject(int id, int amount)
        {


            var user    = _userManager.FindById(User.Identity.GetUserId());
            var myUser  = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();

            var backProjectModel = new BuckProjectViewModel() 
            {
                Amount         = amount,
                ProjectId      = id,
                BackerId       = myUser.Id,
                backerLastName = myUser.AspNetUser.LastName,
                backerName     = myUser.AspNetUser.FirstName,
                backerMail     = myUser.AspNetUser.Email
            };

            return View(backProjectModel);
      

            

            
        }
        public async Task<ActionResult> VivaPayment(int amount, int projectId, int BackerId) {

            var transactionModel = new TransactionViewModel()
            {
                projectId = projectId,
                transaction = await new PaymentManager().SendPaymentAsync()
            };

            if(transactionModel.transaction )
            {
                var backerProject = new BackerProject() 
                {
                    Amount        = amount,
                    ProjectId     = projectId,
                    UserId        = BackerId,
                    DateInserted  = DateTime.Now,
                    PaymentStatus = "success"
                };

                db.BackerProjects.Add(backerProject);

                var project                = await db.Projects.FindAsync(projectId);
                project.CurrentFundAmount += amount;
                db.Entry(project).State    = EntityState.Modified;

                await db.SaveChangesAsync();
            }
            return View(transactionModel);
        }
    }
}
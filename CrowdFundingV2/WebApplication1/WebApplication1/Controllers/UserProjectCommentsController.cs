using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CF.Data.Context;
using CF.Models.Database;
using WebApplication1.Models;

using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class UserProjectCommentsController : Controller
    {
        private readonly CrowdFundingContext db = new CrowdFundingContext();
        private readonly ApplicationUserManager _userManager;

        public UserProjectCommentsController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

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
            if (projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new Models.ProjectCommentViewModel()
            {
                ProjectId = projectId.Value
            };
            return View(viewModel);
        }

        // POST: UserProjectComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProjectCommentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindById(User.Identity.GetUserId());
                var myUser = db.Users.Where(x => x.AspNetUsersId.Equals(user.Id)).FirstOrDefault();

                var comment = new UserProjectComment()
                {
                    ProjectId = viewModel.ProjectId,
                    Text = viewModel.Text,
                    BackerId = myUser.Id,
                    DateInserted = DateTime.Now
                };
                db.UserProjectComments.Add(comment);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", "Project", new { id = viewModel.ProjectId });
            }

            return View(viewModel);
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

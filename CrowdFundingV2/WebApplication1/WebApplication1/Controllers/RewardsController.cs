using CF.Data.Context;
using CF.Models.Database;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    public class RewardsController : Controller
    {
        private readonly CrowdFundingContext db = new CrowdFundingContext();

        // GET: Rewards
        public async Task<ActionResult> Index()
        {
            var rewards = db.Rewards.Include(r => r.Project);
            return View(await rewards.ToListAsync());
        }

        // GET: Rewards/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reward reward = await db.Rewards.FindAsync(id);
            if (reward == null)
            {
                return HttpNotFound();
            }
            return View(reward);
        }

        // GET: Rewards/Create
        public ActionResult Create(int? projectId)
        {
            if (projectId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var viewModel = new RewardViewModel()
            {
                ProjectId = projectId.Value
            };
            return View(viewModel);
        }

        // POST: Rewards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RewardViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var reward = new Reward()
                {
                    ProjectId         = viewModel.ProjectId,
                    Name              = viewModel.Title,
                    Description       = viewModel.Description,
                    MaxAvailable      = viewModel.MaxAvailable,
                    CurrentAvailable  = viewModel.MaxAvailable,
                    MinRequiredAmount = viewModel.MinAmount,
                    MaxRequiredAmount = viewModel.MaxAmount,
                    DateInserted      = DateTime.Now,
                    IsAvailable       = true,
                    
                };
                db.Rewards.Add(reward);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "Project", new { id = viewModel.ProjectId});
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

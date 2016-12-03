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

namespace WebApplication1.Controllers
{
    public class RewardsController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();

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
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title");
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
                    ProjectId = viewModel.ProjectId,
                    Name = viewModel.Title,
                    Description = viewModel.Description,
                    MaxAvailable = viewModel.MaxAvailable,
                    CurrentAvailable = viewModel.MaxAvailable,
                    MinRequiredAmount = viewModel.MinAmount,
                    MaxRequiredAmount = viewModel.MaxAmount,
                    DateInserted = DateTime.Now,
                    IsAvailable = true
                };
                db.Rewards.Add(reward);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", "Project", new { id = viewModel.ProjectId});
            }
            
            return View(viewModel);
        }

        // GET: Rewards/Edit/5
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", reward.ProjectId);
            return View(reward);
        }

        // POST: Rewards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,Name,DateInserted,Description,MinRequiredAmount,MaxRequiredAmount,MaxAvailable,CurrentAvailable,IsAvailable")] Reward reward)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reward).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", reward.ProjectId);
            return View(reward);
        }

        // GET: Rewards/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reward reward = await db.Rewards.FindAsync(id);
            db.Rewards.Remove(reward);
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

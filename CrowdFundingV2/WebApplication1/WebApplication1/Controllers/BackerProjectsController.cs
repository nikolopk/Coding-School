using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using CF.Data.Context;
using CF.Models.Database;

namespace WebApplication1.Controllers
{
    public class BackerProjectsController : Controller
    {
        private readonly CrowdFundingContext db = new CrowdFundingContext();

        // GET: BackerProjects
        public async Task<ActionResult> Index()
        {
            var backerProjects = db.BackerProjects.Include(b => b.Project).Include(b => b.User);
            return View(await backerProjects.ToListAsync());
        }

        // GET: BackerProjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackerProject backerProject = await db.BackerProjects.FindAsync(id);
            if (backerProject == null)
            {
                return HttpNotFound();
            }
            return View(backerProject);
        }

        // GET: BackerProjects/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title");
            ViewBag.UserId = new SelectList(db.Users, "Id", "PhotoUrl");
            return View();
        }

        // POST: BackerProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ProjectId,UserId,Amount,DateInserted,PaymentStatus")] BackerProject backerProject)
        {
            if (ModelState.IsValid)
            {
                db.BackerProjects.Add(backerProject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", backerProject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "PhotoUrl", backerProject.UserId);
            return View(backerProject);
        }

        // GET: BackerProjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackerProject backerProject = await db.BackerProjects.FindAsync(id);
            if (backerProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", backerProject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "PhotoUrl", backerProject.UserId);
            return View(backerProject);
        }

        // POST: BackerProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ProjectId,UserId,Amount,DateInserted,PaymentStatus")] BackerProject backerProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(backerProject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Title", backerProject.ProjectId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "PhotoUrl", backerProject.UserId);
            return View(backerProject);
        }

        // GET: BackerProjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BackerProject backerProject = await db.BackerProjects.FindAsync(id);
            if (backerProject == null)
            {
                return HttpNotFound();
            }
            return View(backerProject);
        }

        // POST: BackerProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            BackerProject backerProject = await db.BackerProjects.FindAsync(id);
            db.BackerProjects.Remove(backerProject);
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

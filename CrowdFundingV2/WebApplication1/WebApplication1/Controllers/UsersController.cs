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
    public class UsersController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();


        // GET: Users
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.AspNetUser);
            return View(await users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PhotoUrl,AspNetUsersId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", user.AspNetUsersId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", user.AspNetUsersId);
            var aspnetUser = user.AspNetUser;
            var viewModel = new UserDetailsViewModel()
            {
                Email = aspnetUser.Email,
                FirstName = aspnetUser.FirstName,
                LastName = aspnetUser.LastName,
                PhoneNumber = aspnetUser.PhoneNumber
            };
            return View(viewModel);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserDetailsViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FindAsync(userViewModel.Id);
                if(user == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                user = new CF.Models.Database.User()
                {
                   // AspNetUser = aspnetUser,
                };
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            //ViewBag.AspNetUsersId = new SelectList(db.AspNetUsers, "Id", "Email", user.AspNetUsersId);
            return View(userViewModel);
        }

        // GET: Users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
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

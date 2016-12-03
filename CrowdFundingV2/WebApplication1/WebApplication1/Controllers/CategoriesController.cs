using CF.Data.Context;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers {
    [RequireHttps]
    public class CategoriesController : Controller
    {
        private readonly CrowdFundingContext db = new CrowdFundingContext();

        public CategoriesController()
        {

        }
        
        public ActionResult Get(int? id, string filter)
        {
            var categories = db.Categories
                .Include(p => p.Projects)
                .Select(y  => new CategoryViewModel()
                {
                    Id         = y.Id,
                    Name       = y.Name,
                    NoProjects = y.Projects.Count(x => x.DueDate >= DateTime.Now)
                });

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = categories
                             .Where(x => x.Id == id).FirstOrDefault();

            if(category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var categoryStaffProject = db.Projects
               .Include(p            => p.User)
               .Include(p            => p.BackerProjects)
               .Include(p            => p.UserProjectComments)
               .Where(p              => p.CategoryId == id && p.DueDate >= DateTime.Now)
               .OrderByDescending(x  => x.DateInserted)
               .Select(y             => new BasicProjectInfoViewModel()
               {
                   Id                 = y.Id,
                   Title              = y.Title,
                   CreatorFullName    = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.LastName,
                   Description        = y.Description,
                   CurrentFund        = y.CurrentFundAmount,
                   Ratio              = (int)Math.Floor((y.Ratio * 100)),
                   CurrentBackerCount = y.BackerProjects.Count(x => x.ProjectId == y.Id),
                   DueDate            = y.DueDate,
                   NoComments         = y.UserProjectComments.Count(x => x.ProjectId == y.Id),
               });

            var categoryDisplayProject = categoryStaffProject.ToList();

            var categoryPopularProject = db.Projects
               .Include(p              => p.User)
               .Include(p              => p.BackerProjects)
               .Include(p              => p.UserProjectComments)
               .Where(p                => p.CategoryId == id && p.DueDate >= DateTime.Now)
               .Select(y               => new BasicProjectInfoViewModel()
               {
                   Id                 = y.Id,
                   Title              = y.Title,
                   CreatorFullName    = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.LastName,
                   Description        = y.Description,
                   CurrentFund        = y.CurrentFundAmount,
                   Ratio              = (int)Math.Floor((y.Ratio * 100)),
                   CurrentBackerCount = y.BackerProjects.Count(x => x.ProjectId == y.Id),
                   DueDate            = y.DueDate,
                   NoComments         = y.UserProjectComments.Count(x => x.ProjectId == y.Id),
               })
               .OrderByDescending(x => x.CurrentBackerCount);

            var yesterday            = DateTime.Now.AddDays(-1);
            var categoryTodayProject = db.Projects
               .Include(p            => p.User)
               .Include(p            => p.BackerProjects)
               .Include(p            => p.UserProjectComments)
               .Where(p              => p.CategoryId == id && p.DueDate >= DateTime.Now && p.DateInserted > yesterday)
               .Select(y             => new BasicProjectInfoViewModel()
               {
                   Id                 = y.Id,
                   Title              = y.Title,
                   CreatorFullName    = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.LastName,
                   Description        = y.Description,
                   CurrentFund        = y.CurrentFundAmount,
                   Ratio              = (int)Math.Floor((y.Ratio * 100)),
                   CurrentBackerCount = y.BackerProjects.Count(x => x.ProjectId == y.Id),
                   DueDate            = y.DueDate,
                   NoComments         = y.UserProjectComments.Count(x => x.ProjectId == y.Id),
               })
               .OrderByDescending(x => x.CurrentBackerCount);

            var categoryFundedProject = db.Projects
               .Include(p             => p.User)
               .Include(p             => p.BackerProjects)
               .Include(p             => p.UserProjectComments)
               .Where(p               => p.CategoryId == id && p.DueDate >= DateTime.Now)
               .Select(y              => new BasicProjectInfoViewModel()
               {
                   Id                 = y.Id,
                   Title              = y.Title,
                   CreatorFullName    = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.LastName,
                   Description        = y.Description,
                   CurrentFund        = y.CurrentFundAmount,
                   Ratio              = (int)Math.Floor((y.Ratio * 100)),
                   CurrentBackerCount = y.BackerProjects.Count(x => x.ProjectId == y.Id),
                   DueDate            = y.DueDate,
                   NoComments         = y.UserProjectComments.Count(x => x.ProjectId == y.Id),
               })
               .OrderByDescending(x => x.CurrentFund);

           if (filter == "Popular")
            {
                categoryDisplayProject = categoryPopularProject.ToList();
            }
            else if (filter == "Today Launched")
            {
                categoryDisplayProject = categoryTodayProject.ToList();
            }
            else if (filter == "Most Funded")
            {
                categoryDisplayProject = categoryFundedProject.ToList();
            }

            var viewModel = new CategoryDetailsViewModel()
            {
                 Id             = category.Id,
                Name            = category.Name,
                NoProjects      = category.NoProjects,
                StaffProjects   = categoryStaffProject.ToList(),
                PopularProjects = categoryPopularProject.ToList(),
                TodayProjects   = categoryTodayProject.ToList(),
                FundedProjects  = categoryFundedProject.ToList(),
                DisplayProjects = categoryDisplayProject,
                Categories      = categories.ToList()
            };

            return View("Index",viewModel);
        }
    }
}

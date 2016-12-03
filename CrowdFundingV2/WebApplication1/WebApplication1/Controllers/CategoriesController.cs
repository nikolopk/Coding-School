using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using WebApplication1.Models;
using System.Net;

namespace WebApplication1.Controllers
{
    [RequireHttps]
    public class CategoriesController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();
        
        public ActionResult Get(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = db.Categories
                             .Include(p => p.Projects)
                             .Select(y => new CategoryViewModel()
                             {
                                 Id = y.Id,
                                 Name = y.Name,
                                 NoProjects = y.Projects.Where(x=>x.DueDate >= DateTime.Now).Count()
                             })
                             .Where(x => x.Id == id).FirstOrDefault();

            if(category == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            var categoryPopularProject = db.Projects
               .Include(p => p.User)
               .Include(p => p.BackerProjects)
               .Include(p => p.UserProjectComments)
               .Where(p => p.CategoryId == id && p.DueDate >= DateTime.Now)
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
               })
               .OrderByDescending(x=>x.CurrentBackerCount);

            var viewModel = new CategoryDetailsViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                NoProjects = category.NoProjects,
                PopularProjects = categoryPopularProject.ToList()
            };

            return View("Index",viewModel);
        }
    }
}

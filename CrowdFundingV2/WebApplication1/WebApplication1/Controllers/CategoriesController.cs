using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RequireHttps]
    public class CategoriesController : Controller
    {
        private CrowdFundingContext db = new CrowdFundingContext();

        public ActionResult Index()
        {
            var popularProject = db.Projects
               .Include(p => p.User)
               .Include(p => p.BackerProjects)
               .Include(p => p.UserProjectComments)
               .Where(p => p.DueDate >= DateTime.Now)
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
               }).Take(4);

            return View("Category");
        }
    }
}

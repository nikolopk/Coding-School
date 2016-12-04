using CF.Models.Database;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApplication1.Models;


namespace WebApplication1.Extensions {
    public static class ProjectExtensions
    {
        public static IEnumerable<BasicProjectInfoViewModel> CreateBasicProjectInfoViewModel(this IQueryable<Project> projects)
        {
            return projects.Select(y => CreateBasicProjectInfoViewModel(y)).ToList();
        }
        public static BasicProjectInfoViewModel CreateBasicProjectInfoViewModel(this Project y )
        {
            return new BasicProjectInfoViewModel()
            {
                Id = y.Id,
                Title = y.Title,
                CreatorFullName = y.User.AspNetUser.FirstName + " " + y.User.AspNetUser.LastName,
                Description = y.Description,
                CurrentFund = y.CurrentFundAmount,
                Ratio = (int) ( ( (double) y.CurrentFundAmount / y.TargetAmount ) * 100 ),
                CurrentBackerCount = y.BackerProjects.Count(x => x.ProjectId == y.Id),
                DueDate = y.DueDate,
                NoComments = y.UserProjectComments.Count(x => x.ProjectId == y.Id),
                ImageUrl = y.PhotoUrl
            };
        }
    }
}
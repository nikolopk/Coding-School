using CF.Models.Database;
using CF.Models.MVC.Category;
using CF.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CF.Controllers
{
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        IManageCategory _categoryManager;
        public CategoryController(IManageCategory categoryManager)
        {
            _categoryManager = categoryManager;
        }
        public ActionResult Index(int? page)
        {
            var categoryListViewModel = new CategoryListViewModel();
            categoryListViewModel.Categories =
                _categoryManager.GetAll();
            
            

            return View(categoryListViewModel);
        }
    }
}

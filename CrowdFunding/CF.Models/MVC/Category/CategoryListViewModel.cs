using System.Collections.Generic;

namespace CF.Models.MVC.Category
{
    public class CategoryListViewModel : ICachableModel
    {
        public CategoryListViewModel()
        {
            Categories = new List<CategoryViewModel>();
        }
        public IList<CategoryViewModel> Categories { get; set; }

    }
}

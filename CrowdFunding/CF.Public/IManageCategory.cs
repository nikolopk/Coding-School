using CF.Models.MVC.Category;
using System.Collections.Generic;

namespace CF.Public
{
    public interface IManageCategory
    {
        List<CategoryViewModel> GetAll();
    }
}

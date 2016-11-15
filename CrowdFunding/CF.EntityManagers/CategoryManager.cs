using CF.Data2.UnitOfWork;
using CF.Models.Database;
using CF.Models.MVC.Category;
using CF.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.EntityManagers
{
    public class CategoryManager : IManageCategory
    {
        private IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<CategoryViewModel> GetAll()
        {
            var categories =
                _unitOfWork.Repository<Category>()
                    .Query()
                    .Include(i => i.Projects)
                    .OrderBy(q => q
                        .OrderBy(c => c.Name))
                    //.Filter(q => q.ContactName != null)
                    .Get();
                    

            _unitOfWork.Save();
            return categories.Select(x=> 
                                        new CategoryViewModel() {
                                            Id = x.Id,
                                            Name = x.Name
                                        }).ToList();
            //return null;

        }
    }
}

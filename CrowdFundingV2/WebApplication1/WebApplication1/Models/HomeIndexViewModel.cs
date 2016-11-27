using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HomeIndexViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public BasicProjectInfoViewModel TopProject { get; set; }
    }
}
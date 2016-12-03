using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProjectUpdateViewModel
    {
        public int ProjectId { get; set; }
        public string FullName { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime DateInserted { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ProjectCommentViewModel
    {
        [Required]
        public int ProjectId { get; set; } 
        public string CommentorFullName { get; set; }
        public DateTime DateInserted { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
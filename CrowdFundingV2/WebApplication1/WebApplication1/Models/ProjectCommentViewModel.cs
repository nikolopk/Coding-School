﻿using System;

namespace WebApplication1.Models {
    public class ProjectCommentViewModel
    {
        public string CommentorFullName { get; set; }
        public DateTime DateInserted { get; set; }
        public string Text { get; set; }
    }
}
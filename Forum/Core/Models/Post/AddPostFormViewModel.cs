﻿using Forum.Core.Models.Thread;

namespace Forum.Core.Models.Post
{
    public class AddPostFormViewModel
    {
        public int Id { get; set; }

     
        public string ImageUrl { get; set; } = string.Empty;

      
        public string Description { get; set; } = string.Empty;

      
        public string Creator { get; set; } = string.Empty;

        public int ThreadId { get; set; }

     
        public IEnumerable<ThreadViewModel> Threads { get; set; } = new List<ThreadViewModel>();
    }
}

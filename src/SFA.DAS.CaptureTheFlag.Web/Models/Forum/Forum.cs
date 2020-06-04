using System;
using System.Collections.Generic;

namespace DAS_Capture_The_Flag.Models.Forum
{
    public class Forum
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }

        //public int PostStats { get; set; }
        //public string LastPoster { get; set; }
        //public DateTime LastPostDate { get; set; }
        //public string LastTopicTitle { get; set; }
    }
}
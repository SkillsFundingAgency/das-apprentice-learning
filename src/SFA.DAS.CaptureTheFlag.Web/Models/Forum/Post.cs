using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DAS_Capture_The_Flag.Models.Forum
{
    public class Post
    {
        public int Id { get; set; }
        public int Title { get; set; }
        public int Content { get; set; }
        public DateTime Created { get; set; }

        public virtual IdentityUser User  { get; set; }
        public virtual ForumIndex Forum { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}

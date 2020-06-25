using System;
using System.Collections.Generic;
using DAS_Capture_The_Flag.Data;
using Microsoft.AspNetCore.Identity;

namespace DAS_Capture_The_Flag.Models.Forum
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Content { get; set; }
        public DateTime Created { get; set; }

        /*public virtual IdentityUser User  { get; set; }*/ // Amend to ApplicationUser
        public virtual ApplicationUser User { get; set; }
        public virtual Forum Forum { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }
    }
}

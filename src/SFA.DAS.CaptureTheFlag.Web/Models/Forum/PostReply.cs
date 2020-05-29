using System;
using Microsoft.AspNetCore.Identity;

namespace DAS_Capture_The_Flag.Models.Forum
{
    public class PostReply
    {
        public int Id { get; set; }
        public int Content { get; set; }
        public DateTime Created { get; set; }

        public virtual IdentityUser User { get; set; }
        public virtual Post Post { get; set; }
    }
}

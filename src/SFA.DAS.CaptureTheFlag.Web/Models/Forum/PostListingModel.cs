using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAS_Capture_The_Flag.Models.Forum
{
    public class PostListingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorRating { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public string DatePosted { get; set; }

        public ForumListingModel Forum { get; set; }

        public int RepliesCount { get; set; }
    }
}

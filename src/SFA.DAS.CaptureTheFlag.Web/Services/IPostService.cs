using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Models.Forum;

namespace DAS_Capture_The_Flag.Services
{
    public interface IPostService
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetFilteredPosts(string searchQuery);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
        Task AddReply(PostReply reply);
    }
}

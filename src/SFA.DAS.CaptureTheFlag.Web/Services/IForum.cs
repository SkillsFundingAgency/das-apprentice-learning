using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Models.Forum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.WebEncoders.Testing;

namespace DAS_Capture_The_Flag.Services
{
    public interface IForum
    {
        ForumIndex GetById(int id);
        IEnumerable<ForumIndex> GetAll();
        IEnumerable<IdentityUser> GetAllActiveUsers();

        Task Create(ForumIndex forum);
        Task Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
    }
}

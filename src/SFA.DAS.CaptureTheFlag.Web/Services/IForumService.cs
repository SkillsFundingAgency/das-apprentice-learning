using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Models.Forum;
using Microsoft.AspNetCore.Identity;

namespace DAS_Capture_The_Flag.Services
{
    public interface IForumService
    {
        Forum GetById(int id);
        IEnumerable<Forum> GetAll();
        IEnumerable<IdentityUser> GetAllActiveUsers();

        void Create(Forum forum);
        void Delete(int forumId);
        Task UpdateForumTitle(int forumId, string newTitle);
        Task UpdateForumDescription(int forumId, string newDescription);
    }
}

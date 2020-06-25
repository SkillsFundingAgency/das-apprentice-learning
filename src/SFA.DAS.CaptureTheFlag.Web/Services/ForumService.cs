using DAS_Capture_The_Flag.Models.Forum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAS_Capture_The_Flag.Data;
using Microsoft.EntityFrameworkCore;

namespace DAS_Capture_The_Flag.Services
{
    public class ForumService : IForumService
    {
        // Pass an instant of our dbContext
        private readonly ApplicationDbContext _db;

        public ForumService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Create(Forum forum)
        {
            _db.Forums.Add(forum);
            _db.SaveChanges();
        }

        public void Delete(int forumId)
        {
            var topic = _db.Forums.Find(forumId);
            _db.Forums.Remove(topic);
        }

        public IEnumerable<Forum> GetAll() // returns instance of forum from our database
        {
            return _db.Forums.Include(f => f.Posts);
        }

        //public IEnumerable<IdentityUser> GetAllActiveUsers()
        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        public Forum GetById(int id)
        {
            // Give the first forum that corresponds to where clause: primary key should return single result.
            // Look for all forums
            // Where clause using linq. Specify forum id is equals to the id we pass.
            var forum = _db.Forums.Where(f => f.Id == id)
                // Include posts here too, loading the posts now too
                // The posts have navigation properties too, such as the user, so ThenInclude
                .Include(f => f.Posts).ThenInclude(p => p.User)
                // Include posts here too, loading the posts again in order to get replies from those posts
                // The posts have navigation properties too, such as the user, so ThenInclude
                .Include(f => f.Posts).ThenInclude(p => p.Replies)
                // Replies have a navigation of user who made a reply, so ThenInclude here
                .ThenInclude(r => r.User)
                // Return the first or default and then call return.
                .FirstOrDefault();
            return forum;
        }

        public Task UpdateForumDescription(int forumId, string newDescription)
        {

            throw new NotImplementedException();
        }

        public Task UpdateForumTitle(int forumId, string newTitle)
        {
            throw new NotImplementedException();
        }
    }
}

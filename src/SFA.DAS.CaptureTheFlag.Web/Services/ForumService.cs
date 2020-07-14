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

        public IEnumerable<Forum> GetAll()
        {
            return _db.Forums.Include(f => f.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new NotImplementedException();
        }

        // TODO: Paging Strategy see .Skip .Take methods
        public Forum GetById(int id)
        {
            var forum = _db.Forums.Where(f => f.Id == id)
                .Include(f => f.Posts).ThenInclude(p => p.User)
                .Include(f => f.Posts).ThenInclude(p => p.Replies)
                .ThenInclude(r => r.User)
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

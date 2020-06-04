using System;
using System.Collections.Generic;
using System.Linq;
using DAS_Capture_The_Flag.Models.Forum;
using DAS_Capture_The_Flag.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DAS_Capture_The_Flag.Controllers
{
    // Inject an instance of our ForumService from forum layer into the constructor
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IPostService _postService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        public IActionResult Index()
        {
            IEnumerable<ForumListingModel> forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel {
                    Id = forum.Id,
                    Name = forum.Title,
                    Description = forum.Description

                });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetPostsByForum(id);

            var postListings = posts.Select(post => new PostListingModel
            {
                Id = post.Id,
                AuthorId = post.User.Id,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });

            throw new NotImplementedException();
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
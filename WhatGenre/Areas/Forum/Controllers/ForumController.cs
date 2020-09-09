using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WhatGenre.Areas.Forum.Controllers
{
    [Area("Forum")]
    [Route("Forum")]
    public class ForumController : Controller
    {

        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly UserManager<User> userManager;

        /// <summary>
        ///  Controller to initialise services
        /// </summary>
        /// <param name="postService"></param>
        /// <param name="commentService"></param>
        /// <param name="userManager"></param>
        public ForumController(IPostService postService, ICommentService commentService, UserManager<User> userManager)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        /// <summary>
        ///  gets all posts, displays on index
        /// </summary>
        /// <returns> returns the index view </returns>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await postService.GetAllPosts();
            return View("Post/Index", posts);
        }

        /// <summary>
        /// displays a create form
        /// </summary>
        /// <returns>returns a create form</returns>
        [Authorize]
        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View("Post/Create");
        }

        /// <summary>
        /// creates a new post
        /// </summary>
        /// <param name="post"></param>
        /// <returns> a redirect if the post is successful, or returns the view
        /// if their is errors on the form.
        /// </returns>
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.Now;
                post.User = await userManager.GetUserAsync(HttpContext.User);

                await postService.Save(post);

                return Redirect("Index");
            }

            return View("Post/Create");
        }

        /// <summary>
        /// details page that displays the post with all its comments associated to the post ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns a view with post and comment data </returns>
        [Authorize]
        [HttpGet, Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var posts = await postService.GetPostById(id);
   
            var user = await userManager.FindByIdAsync(posts.UserId);

            posts.User = user;

            var comments = await commentService.FindAllCommentsByPostIdAsync(id);
            posts.Comments = comments;

            return View("Post/Details", posts);
        }

        /// <summary>
        /// returns edit form with current post data by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns edit view</returns>
        [Authorize]
        [HttpGet, Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await postService.GetPostById(id);

            return View("Post/Edit", post);
        }

        /// <summary>
        /// form post gets the id, and the current created date and if it is valid
        /// uses the service to save changes.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns>redirect after successful service function or view if there is an error</returns>
        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Post post)
        {
            if (ModelState.IsValid)
            {
                Post data = await postService.GetPostById(id);

                post.CreatedDate = data.CreatedDate;

                await postService.Edit(id, post);
                return RedirectToAction("Index");
            }

            return View("Post/Edit");
        }

        /// <summary>
        /// returns a delete form with post data
        /// </summary>
        /// <param name="id"></param>
        /// <returns>delete form view</returns>
        [Authorize]
        [HttpGet, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var post = await postService.GetPostById(id);

            return View("Post/Delete", post);
        }

        /// <summary>
        /// deletes post model if the model is not null and is in the db.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="post"></param>
        /// <returns> redirect if successful deletion, otherwise returns a badrequest </returns>
        [Authorize]
        [HttpPost, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id, Post post)
        {
            post = await postService.GetPostById(id);

            if (post != null)
            {
                await postService.Delete(id);
                return Redirect("Index");
            }

            return BadRequest(400);
        }

    }

}
using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WhatGenre.Areas.Forum.Controllers
{
    [Area("Forum"), Route("Forum")]
    public class CommentController : Controller
    {
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly UserManager<User> userManager;

        /// <summary>
        /// comment controller constructor using DI for services.
        /// </summary>
        /// <param name="postService"></param>
        /// <param name="commentService"></param>
        /// <param name="userManager"></param>
        public CommentController(IPostService postService, ICommentService commentService, UserManager<User> userManager)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        /// <summary>
        /// create form for comments
        /// </summary>
        /// <returns>View for creating a comment on a post </returns>
        [HttpGet, Route("Details/{id}/Comment/Create")]
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// creates a new comment by the post id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns>redirects to index if successful, returns create view if errors </returns>
        [Authorize]
        [HttpPost, Route("Details/{id}/Comment/Create")]
        public async Task<IActionResult> Create(int id, Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment = new Comment();
                comment.CommentBody = Request.Form["CommentBody"];
                var user = await userManager.GetUserAsync(HttpContext.User);
                
                comment.UserId = user.Id;
                comment.Post = await postService.GetPostById(id);
                comment.CommentDate = DateTime.Now;

                await commentService.Save(comment);

                return Redirect("Index");
            }

            return View("Create");

        }

        /// <summary>
        /// displays view for editing a comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        [Authorize]
        [HttpGet, Route("Details/{id}/Comment/Edit/{comment_id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var comment = await commentService.GetCommentById(id);

            return View("Edit");
        }

        /// <summary>
        ///  needs doing
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("Details/{id}/Comment/Edit/{comment_id}")]
        public async Task<IActionResult> Edit(int id, Comment comment)
        {
           
            comment = await commentService.GetCommentById(id);

            return View("Edit");
        }

        /// <summary>
        ///  displays view to delete a comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet, Route("Details/{id}/Comment/Delete/{comment_id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var comment = await commentService.GetCommentById(id);

            return View("Delete");
        }

        /// <summary>
        ///  needs doing
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost, Route("Details/{id}/Comment/Delete/{comment_id}")]
        public async Task<IActionResult> Delete(int id, Comment comment)
        {
            comment = await commentService.GetCommentById(id);

            return View("Delete");
        }

    }
}
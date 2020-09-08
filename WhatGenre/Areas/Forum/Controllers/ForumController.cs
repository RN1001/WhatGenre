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

        public ForumController(IPostService postService, ICommentService commentService, UserManager<User> userManager)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await postService.GetAllPosts();
            return View("Post/Index", posts);
        }

        [Authorize]
        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View("Post/Create");
        }

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

        [Authorize]
        [HttpGet, Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await postService.GetPostById(id);

            return View("Post/Edit", post);
        }

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

        [Authorize]
        [HttpGet, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var post = await postService.GetPostById(id);

            return View("Post/Delete", post);
        }

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
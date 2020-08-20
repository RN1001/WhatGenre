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

                return RedirectToAction("Post/Index");
            }

            return View("Post/Create");
        }

        [Authorize]
        [HttpGet, Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var posts = await postService.GetPostById(id);

            posts.UserId = user.Id;

            var comments = await commentService.FindAllCommentsByPostIdAsync(id);
            posts.Comments = comments;

            return View("Post/Details", posts);
        }

        [Authorize]
        [HttpGet, Route("Edit/{id}")]
        public IActionResult Edit()
        {
            return View("Post/Edit");
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id, Post post)
        {
            Post data = await postService.GetPostById(id);

            post.CreatedDate = data.CreatedDate;

            //if (ModelState.IsValid)
            //{ 
            //    await postService.Edit(id, post);
            //    return View("Post/Details");
            //}

            return View("Post/Edit");
        }

        [Authorize]
        [HttpGet, Route("Delete/{id}")]
        public IActionResult Delete()
        {
            return View("Post/Delete");
        }

        [Authorize]
        [HttpPost, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await postService.Delete(id);

            return Redirect("Forum");
        }

    }

}
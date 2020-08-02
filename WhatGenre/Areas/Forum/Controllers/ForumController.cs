using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WhatGenre.Areas.Forum.ViewModels;

namespace WhatGenre.Areas.Forum.Controllers
{
    [Area("Forum"), Route("Forum")]
    public class ForumController : Controller
    {
        private WhatGenreContext context;
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly UserManager<User> userManager;

        public ForumController(IPostService postService, ICommentService commentService, WhatGenreContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.postService = postService;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await postService.GetAllPosts();
            return View("Index", posts);
        }

        [Authorize]
        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.Now;
                post.User = await userManager.FindByNameAsync(User.Identity.Name);

                await postService.Save(post);

                return RedirectToAction("Index");
            }

            return View();
            //return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet, Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var posts = await postService.GetPostById(id);

            posts.UserId = user.Id;

            var comments = await commentService.FindAllCommentsByPostIdAsync(id);
            posts.Comments = comments;

            return View("Details", posts);
        }

    }

}
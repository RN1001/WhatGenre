using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public CommentController(IPostService postService, ICommentService commentService, UserManager<User> userManager)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [HttpGet, Route("Details/{id}/Comment/Create")]
        public IActionResult Create()
        {
            return View();
        }

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

                return RedirectToAction("Index", "Forum");
            }

            return View("Create");

        }

    }
}
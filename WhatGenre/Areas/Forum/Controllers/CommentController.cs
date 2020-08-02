using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WhatGenre.Areas.Forum.Controllers
{
    [Area("Forum")]
    public class CommentController : Controller
    {
        private readonly IPostService postService;

        private readonly ICommentService commentService;

        public CommentController(IPostService postService, ICommentService commentService)
        {
            this.postService = postService;
            this.commentService = commentService;
        }

        public IActionResult Create()
        {
            return View("");
        }
    }
}
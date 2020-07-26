using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WhatGenre.Areas.Forum.Controllers
{
    [Area("Forum"), Route("Forum")]
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet, Route("Add")]
        public IActionResult AddPost()
        {
            return View();
        }

    }
}
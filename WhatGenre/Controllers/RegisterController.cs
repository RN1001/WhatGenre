﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WhatGenre.Models;
using WhatGenre.Interfaces;

namespace WhatGenre.Views.Register
{
    [Route("register")]
    public class RegisterController : Controller
    {

        private readonly IUserService userService;

        private readonly ILogger logger;

        public RegisterController(IUserService userService, ILogger<RegisterController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        { 
            return Content($"Lol");
        }


        [Route("user/{id:int}")]
        public IActionResult GetUser(int id)
        {
            return Content($"{userService.GetUserById(id)}");
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            logger.LogInformation("message");
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {         
            return Content($"{user}");
        }
    }
}
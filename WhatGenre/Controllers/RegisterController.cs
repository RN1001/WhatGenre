using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WhatGenre.Models;

namespace WhatGenre.Views.Register
{
    public class RegisterController : Controller
    {

        private readonly WhatGenreContext db;

        public RegisterController(WhatGenreContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Content($"{user}");
        }
    }
}
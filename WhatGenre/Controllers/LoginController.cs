using Microsoft.AspNetCore.Mvc;

namespace WhatGenre.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WhatGenre.Areas.Store.Controllers
{
    [Area("Store"), Route("Store")]
    public class StoreController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet, Route("Products")]
        public IActionResult Products()
        {
            return View("Products");
        }
    }
}
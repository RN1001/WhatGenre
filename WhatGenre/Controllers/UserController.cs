using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace WhatGenre.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        private readonly ILogger logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await userService.GetAllUsers();
            return Content($"{users}");
        }


        [HttpGet, Route("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await userService.GetAllUsers();
            return Content($"{user.ToArray()}");
        }

        
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WhatGenre.Models;
using WhatGenre.Interfaces;

namespace WhatGenre.Views.Register
{
    [Route("register")]
    public class RegisterController : Controller
    {

        private readonly IUserRepository userRepository;

        private readonly ILogger logger;

        public RegisterController(IUserRepository userRepository, ILogger<RegisterController> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            logger.LogInformation($"message: {userRepository.GetById(1)}");
            return Content($"Lol");
        }


        [Route("user/{id:int}")]
        public IActionResult GetUser(int id)
        {
            return Content($"{id}");
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
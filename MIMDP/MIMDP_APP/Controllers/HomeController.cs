using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            UserData user = GetUserData();
            ViewData["UserName"]  = user.Name;
            return View(user);
        }

        private UserData GetUserData()
        {
            UserData user = new UserData()
            {
                Id = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value),
                Name = User.Claims.FirstOrDefault(c => c.Type == "Name")?.Value,
                Email = User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value
            };

            return user;
        }

   

    }
}

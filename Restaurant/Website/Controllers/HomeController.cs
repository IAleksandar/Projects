﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(User model)
        {
            return View(model);
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register_User(User model)
        {
            Restaurant.Controllers.RestaurantController api = new Restaurant.Controllers.RestaurantController();
            api.Register(model.Name, model.Email, model.Password);
            return RedirectToAction("Index");
        }

        public IActionResult LogIn(User model)
        {
            Restaurant.Controllers.RestaurantController api = new Restaurant.Controllers.RestaurantController();
            if ((LogedInUser.logInUserId = api.LogIn(model.Email, model.Password)) != 0)
                return RedirectToAction("Menu");
            return RedirectToAction("Index");
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Order(Order order)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

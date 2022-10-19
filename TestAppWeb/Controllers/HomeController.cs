﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestAppWeb.Models;

namespace TestAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WelCome()
        {
            if (HttpContext.Session.GetString("userId") != null)
            {
                ViewBag.apikey = HttpContext.Session.GetString("apikey");
                return View();
            }
            else { 
              return RedirectToAction("Login","User");
            }
        }


        public IActionResult Privacy()
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
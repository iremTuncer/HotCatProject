﻿using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

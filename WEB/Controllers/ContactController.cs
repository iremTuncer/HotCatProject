﻿using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

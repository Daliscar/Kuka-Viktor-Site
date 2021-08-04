using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViktorLabs.Models;

namespace ViktorLabs.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(ILogger<RegisterController> logger)
        {
            _logger = logger;
        }

        public IActionResult RegisterPage()
        {
            return View();
        }
        public IActionResult RegisterConfirm()
        {
            return View();
        }
    }
}

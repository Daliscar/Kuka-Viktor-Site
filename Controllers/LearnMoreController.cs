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
    public class LearnMoreController : Controller
    {
        private readonly ILogger<LearnMoreController> _logger;

        public LearnMoreController(ILogger<LearnMoreController> logger)
        {
            _logger = logger;
        }

        public IActionResult LearnMorePage()
        {
            return View();
        }
    }
}
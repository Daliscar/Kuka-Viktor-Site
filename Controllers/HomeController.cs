using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ViktorLabs.Models;

namespace ViktorLabs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public bool show;

        public HomeController(ILogger<HomeController> logger,
         UserManager<IdentityUser> userManager,
         SignInManager<IdentityUser> signInManager )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult SecretPage()
        {
            return View();
        }

        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginPage(string username, string password)
        {
            //login functionality

            var user = await _userManager.FindByNameAsync(username);

            if(user != null)
            {
                //sign in
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                
                if(signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    show = true;
                }
            }

            return View();
        }
        public IActionResult RegisterPage()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterPage(string username, string password)
        {
            //register functionality

            var user = new IdentityUser
            {
                UserName = username
            };

            var result = await _userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {
                //sign in
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);
                
                if(signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}

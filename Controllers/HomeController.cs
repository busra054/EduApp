using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace WebApplication_Deneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Home Index page
        public IActionResult Index()
        {
            // Kullanýcý giriþ yapmamýþsa
            if (!User.Identity.IsAuthenticated)
            {
                return View("Index");  // Giriþ yapmamýþ kullanýcý için ana sayfayý göster
            }

            // Giriþ yapmýþ kullanýcý için profil sayfasýna yönlendir
            return RedirectToAction("Profile", "User");
        }
        public IActionResult AccessDenied()
        {
            return View();
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

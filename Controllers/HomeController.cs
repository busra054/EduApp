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
            // Kullan�c� giri� yapmam��sa
            if (!User.Identity.IsAuthenticated)
            {
                return View("Index");  // Giri� yapmam�� kullan�c� i�in ana sayfay� g�ster
            }

            // Giri� yapm�� kullan�c� i�in profil sayfas�na y�nlendir
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

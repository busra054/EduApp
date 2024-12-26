using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Deneme.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            // Çıkış sonrası bir mesaj göstermek isterseniz burayı kullanabilirsiniz.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // Kullanıcıyı sistemden çıkart (Cookie temizleme, oturumu sonlandırma vs.)
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

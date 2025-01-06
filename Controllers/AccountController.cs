using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_Deneme.Models;
using WebApplication_Deneme.DataAccess;
using BCrypt.Net; // Şifre doğrulama için
using Microsoft.AspNetCore.Identity;

namespace WebApplication_Deneme.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AccountController(ApplicationDbContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Login GET metodu
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı.");
                    return View(model);
                }

                // Şifre doğrulama
                if (user.PasswordHash != model.Password)
                {
                    ModelState.AddModelError(string.Empty, "Şifre hatalı.");
                    return View(model);
                }

                // Başarı durumunda oturum açılır
                TempData["SuccessMessage"] = "Giriş başarılı!";

                // Kullanıcı rolüne göre yönlendirme
                if (user.Role == "Admin")
                    return RedirectToAction("Index", "Admins");
                if (user.Role == "Öğrenci")
                    return RedirectToAction("Index", "Admins");

                return RedirectToAction("Index", "Admins");
            }

            return View(model);
        }



    }
}

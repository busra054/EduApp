using Microsoft.AspNetCore.Mvc;
using WebApplication_Deneme.Models;
using WebApplication_Deneme.DataAccess;
using BCrypt.Net;

namespace WebApplication_Deneme.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Kayıt sayfasını görüntüle
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kullanıcı mevcut mu kontrol et
                if (_context.Users.Any(u => u.Email == model.Email))
                {
                    ViewBag.Message = "Bu e-posta adresi zaten kullanılıyor.";
                    return View("Index");
                }

                // Kullanıcı oluştur
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    Role = model.Role // Burada Role doğru şekilde alınıyor olmalı.
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                // Başarılı olursa giriş sayfasına yönlendir
                return RedirectToAction("Index", "Login");
            }

            return View("Index");
        }
    }


}


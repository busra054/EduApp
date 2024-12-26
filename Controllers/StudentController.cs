using Microsoft.AspNetCore.Mvc;
using WebApplication_Deneme.Models;
using WebApplication_Deneme.DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication_Deneme.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Öğrenci profili sayfası
        public IActionResult Profile()
        {
            var userId = User.Identity.Name; // Giriş yapan kullanıcının email veya username
            var student = _context.Users.FirstOrDefault(u => u.Email == userId);
            if (student == null)
            {
                return RedirectToAction("Login", "User"); // Eğer öğrenci bulunamazsa, login sayfasına yönlendir
            }
            var messages = _context.Messages.Where(m => m.ReceiverId == student.Id || m.SenderId == student.Id).ToList();
            return View(student); // Student modelini view'e gönder
        }
    }
}

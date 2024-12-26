using Microsoft.AspNetCore.Mvc;
using WebApplication_Deneme.DataAccess;

namespace WebApplication_Deneme.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Öğrenci profili sayfası
        public IActionResult Profile()
        {
            var userId = User.Identity.Name; // Giriş yapan kullanıcının email veya username
            var teacher = _context.Users.FirstOrDefault(u => u.Email == userId);
            if (teacher == null)
            {
                return RedirectToAction("Login", "User"); // Eğer öğrenci bulunamazsa, login sayfasına yönlendir
            }
            var messages = _context.Messages.Where(m => m.ReceiverId == teacher.Id || m.SenderId == teacher.Id).ToList();
            return View(teacher); // Student modelini view'e gönder
        }

    }
}

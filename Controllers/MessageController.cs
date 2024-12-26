using Microsoft.AspNetCore.Mvc;
using WebApplication_Deneme.Models;
using WebApplication_Deneme.DataAccess;

namespace WebApplication_Deneme.Controllers
{
    public class MessageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SendMessage(int receiverId, string messageText)
        {
            var senderId = int.Parse(User.Identity.Name); // Assuming user id is the name for simplicity
            var message = new Message
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                MessageText = messageText,
                SentDate = DateTime.Now
            };
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("Profile");
        }
    }
}

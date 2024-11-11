using Microsoft.AspNetCore.Mvc;
using Lab5.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab5.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProfileController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }
    }
}

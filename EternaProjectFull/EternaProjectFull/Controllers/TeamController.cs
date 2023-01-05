using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Members.ToList());
        }
    }
}

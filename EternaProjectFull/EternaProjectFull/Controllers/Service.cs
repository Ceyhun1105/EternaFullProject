using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Controllers
{
    public class Service : Controller
    {
        private readonly AppDbContext _context;

        public Service(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }
    }
}

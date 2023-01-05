using EternaProjectFull.Models;
using EternaProjectFull.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutViewModel = new AboutViewModel()
            {
                Counts = _context.Counts.ToList(),
                Clients= _context.Clients.ToList(),
                Testimonials = _context.Testimonials.ToList()
            };   
            return View(aboutViewModel);
        }
    }
}

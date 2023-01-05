using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Services.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service is null) return NotFound();
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            if (service is null) return NotFound();
            return View(service);
        }
        [HttpPost]
        public IActionResult Update(Service service)
        {
            Service service1 = _context.Services.FirstOrDefault(x => x.Id == service.Id);
            if (service1 is null) return NotFound();
            service1.Icon = service.Icon;
            service1.Title = service.Title;
            service1.Description = service.Description;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

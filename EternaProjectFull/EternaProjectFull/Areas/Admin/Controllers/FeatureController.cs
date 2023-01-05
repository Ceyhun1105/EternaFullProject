using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly AppDbContext _context;

        public FeatureController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Features.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feature feature)
        {
            if (ModelState.IsValid)
            {
                _context.Features.Add(feature);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (feature is null) return NotFound();
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Feature feature = _context.Features.FirstOrDefault(x => x.Id == id);
            if (feature is null) return NotFound();
            return View(feature);
        }
        [HttpPost]
        public IActionResult Update(Feature feature)
        {
            Feature feature1 = _context.Features.FirstOrDefault(x => x.Id == feature.Id);
            if (feature1 is null) return NotFound();
            feature1.Icon = feature.Icon;
            feature1.Title = feature.Title;
            feature1.Description = feature.Description;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

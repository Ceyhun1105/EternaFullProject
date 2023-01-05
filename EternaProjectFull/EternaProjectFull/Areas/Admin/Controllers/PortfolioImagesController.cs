using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioImagesController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioImagesController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.PortfolioImages.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfolioImages portfolioimages)
        {
            if (ModelState.IsValid)
            {
                _context.PortfolioImages.Add(portfolioimages);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            PortfolioImages portfolioimages = _context.PortfolioImages.FirstOrDefault(x => x.Id == id);
            if (portfolioimages is null) return NotFound();
            _context.PortfolioImages.Remove(portfolioimages);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            PortfolioImages portfolioimages = _context.PortfolioImages.FirstOrDefault(x => x.Id == id);
            if (portfolioimages is null) return NotFound();
            return View(portfolioimages);
        }
        [HttpPost]
        public IActionResult Update(PortfolioImages portfolioimages)
        {
            PortfolioImages portfolioimages1 = _context.PortfolioImages.FirstOrDefault(x => x.Id == portfolioimages.Id);
            if (portfolioimages1 is null) return NotFound();
            portfolioimages1.PortfolioId = portfolioimages.PortfolioId;
            portfolioimages1.ImageUrl = portfolioimages.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
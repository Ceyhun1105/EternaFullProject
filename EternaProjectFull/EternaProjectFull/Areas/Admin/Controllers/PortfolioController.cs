using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Portfolios.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Portfolio portfolio)
        {
            if (ModelState.IsValid)
            {
                _context.Portfolios.Add(portfolio);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Portfolio portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio is null) return NotFound();
            _context.Portfolios.Remove(portfolio);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Portfolio portfolio = _context.Portfolios.FirstOrDefault(x => x.Id == id);
            if (portfolio is null) return NotFound();
            return View(portfolio);
        }
        [HttpPost]
        public IActionResult Update(Portfolio portfolio)
        {
            Portfolio portfolio1 = _context.Portfolios.FirstOrDefault(x => x.Id == portfolio.Id);
            if (portfolio1 is null) return NotFound();
            portfolio1.CategoryId = portfolio.CategoryId;
            portfolio1.Client = portfolio.Client;
            portfolio1.Title = portfolio.Title;
            portfolio1.Description = portfolio.Description;
            portfolio1.ProjectDate = portfolio.ProjectDate;
            portfolio1.ProjectUrl = portfolio.ProjectUrl;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
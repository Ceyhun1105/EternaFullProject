using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountController : Controller
    {
        private readonly AppDbContext _context;

        public CountController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Counts.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Count count)
        {
            if (ModelState.IsValid)
            {
                _context.Counts.Add(count);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Count count = _context.Counts.FirstOrDefault(x => x.Id == id);
            if (count is null) return NotFound();
            _context.Counts.Remove(count);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Count count = _context.Counts.FirstOrDefault(x => x.Id == id);
            if (count is null) return NotFound();
            return View(count);
        }
        [HttpPost]
        public IActionResult Update(Count count)
        {
            Count count1 = _context.Counts.FirstOrDefault(x => x.Id == count.Id);
            if (count1 is null) return NotFound();
            count1.Icon = count.Icon;
            count1.FinalCount = count.FinalCount;
            count1.FindUrl = count.FindUrl;
            count1.TitleLeft = count.TitleLeft;
            count1.TitleRight = count.TitleRight;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

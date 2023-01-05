using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category is null) return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Update(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x=>x.Id == id);
            if (category is null) return NotFound();
            return View(category);
        }
        [HttpPost]
        public IActionResult Update(Category category)
        {
            Category category1= _context.Categories.FirstOrDefault(x=>x.Id==category.Id);
            if (category1 is null) return NotFound();
            category1.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

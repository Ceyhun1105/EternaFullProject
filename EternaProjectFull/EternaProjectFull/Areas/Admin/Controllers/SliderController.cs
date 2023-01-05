using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Sliders.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                _context.Sliders.Add(slider);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider is null) return NotFound();
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(x => x.Id == id);
            if (slider is null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider slider1 = _context.Sliders.FirstOrDefault(x => x.Id == slider.Id);
            if (slider1 is null) return NotFound();
            slider1.ImageUrl = slider.ImageUrl;
            slider1.TitleLeft = slider.TitleLeft;
            slider1.TitleRight = slider.TitleRight;
            slider1.ReadMoreUrl = slider.ReadMoreUrl;
            slider1.Description = slider.Description;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

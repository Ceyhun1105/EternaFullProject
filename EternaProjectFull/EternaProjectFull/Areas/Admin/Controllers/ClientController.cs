using EternaProjectFull.Models;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientController : Controller
    {
        private readonly AppDbContext _context;

        public ClientController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Clients.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Client client = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (client is null) return NotFound();
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Client client = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (client is null) return NotFound();
            return View(client);
        }
        [HttpPost]
        public IActionResult Update(Client client)
        {
            Client client1 = _context.Clients.FirstOrDefault(x => x.Id == client.Id);
            if (client1 is null) return NotFound();
            client1.ImageUrl = client.ImageUrl;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

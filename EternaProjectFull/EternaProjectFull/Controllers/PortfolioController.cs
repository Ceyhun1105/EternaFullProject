using EternaProjectFull.Models;
using EternaProjectFull.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EternaProjectFull.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PortfolioViewModel portfolioViewModel = new PortfolioViewModel()
            {
                Categories=_context.Categories.ToList(),
                Portfolios=_context.Portfolios.Include(x=>x.Category).Include(x=>x.PortfolioImages).ToList(),
                Clients=_context.Clients.ToList()
            };   
            return View(portfolioViewModel);
        }
        public IActionResult Detail(int id)
        {
            Portfolio portfolio = _context.Portfolios.Include(x=>x.Category).Include(x=>x.PortfolioImages).ToList().FirstOrDefault(x => x.Id == id);
            if (portfolio == null)
            {
                return NotFound();
            }
            return View(portfolio);
        }
    }
}

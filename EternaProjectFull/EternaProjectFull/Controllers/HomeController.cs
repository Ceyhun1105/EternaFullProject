using EternaProjectFull.Models;
using EternaProjectFull.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EternaProjectFull.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel()
            {
                Sliders = _appDbContext.Sliders.ToList(),
                Features= _appDbContext.Features.ToList(),
                Services= _appDbContext.Services.ToList(),
                Clients= _appDbContext.Clients.ToList()
            };
            return View(homeViewModel);
        }

    }
}
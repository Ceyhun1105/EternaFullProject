using EternaProjectFull.Models;

namespace EternaProjectFull.ViewModels
{
    public class PortfolioViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Portfolio> Portfolios { get; set; }
        public List<PortfolioImages> PortfolioImages { get; set; }
        public List<Client> Clients { get; set; }
    }
}

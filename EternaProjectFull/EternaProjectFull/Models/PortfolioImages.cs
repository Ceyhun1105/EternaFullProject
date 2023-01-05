namespace EternaProjectFull.Models
{
    public class PortfolioImages
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public string ImageUrl { get; set; }


        public Portfolio Portfolios { get; set; }
    }
}

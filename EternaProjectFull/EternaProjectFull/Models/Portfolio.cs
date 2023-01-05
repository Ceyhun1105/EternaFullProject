﻿namespace EternaProjectFull.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Client { get; set; }
        public string Title  { get; set; }
        public string Description { get; set; }
        public string ProjectUrl { get; set; }
        public DateTime ProjectDate { get; set; }
        public Category Category { get; set; }
        public List<PortfolioImages> PortfolioImages { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;

namespace EternaProjectFull.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Count> Counts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Team> Members { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioImages> PortfolioImages { get; set; }
    }
}

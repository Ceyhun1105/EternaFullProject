using System.ComponentModel.DataAnnotations;

namespace EternaProjectFull.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(maximumLength:20)]
        public string Name { get; set; }
        public List<Portfolio> Portfolios { get; set; }

    }
}

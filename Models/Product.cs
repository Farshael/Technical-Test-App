using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalTest.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public bool IsDeleted { get; set; } = false;

        [ForeignKey("ProductCategory")]
        public int ProductCategoryId { get; set; }

        public ProductCategory? ProductCategory { get; set; }
    }
}

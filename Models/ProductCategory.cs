using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; } = false;
    }
}

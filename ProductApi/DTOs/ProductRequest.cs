using ProductApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs
{
    public class ProductRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; }
    }
}

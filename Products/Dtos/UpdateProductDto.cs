using System.ComponentModel.DataAnnotations;

namespace Products.Dtos
{
    public record UpdateProductDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
    }
}
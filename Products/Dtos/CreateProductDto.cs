using System.ComponentModel.DataAnnotations;

namespace Products.Dtos
{
    public record CreateProductDto
    {
        [Required]
        public string Name { get; init; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
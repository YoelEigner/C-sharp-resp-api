

namespace Products.Models
{
    public record Product
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
namespace Products.Dtos
{
    public record CreateProductDto
    {
        public string Name { get; init; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
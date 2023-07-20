namespace Products.Dtos
{
    public record ProductDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
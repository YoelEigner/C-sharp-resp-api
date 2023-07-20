using Products.Dtos;
using Products.Models;

namespace Products
{
    public static class Extentions
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = product.Quantity,
                Price = product.Price
            };
        }
    }
}
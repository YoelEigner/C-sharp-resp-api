
using Products.Models;

namespace Products.Repository
{
    public interface IProductsRepository
    {
        Task<Product> GetItemAsync(Guid id);
        Task<IEnumerable<Product>> GetItemsAsync();
        Task CreateItemAsync(Product item);
        Task UpdateItemAsync(Product item);
        Task DeleteItemAsync(Guid id);
    }
}
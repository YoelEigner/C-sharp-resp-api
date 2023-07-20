
using MongoDB.Driver;
using Products.Models;

namespace Products.Repository
{
    public class MongoDBProductsRepository : IProductsRepository
    {

        private const string databaseName = "products";
        private const string collectionName = "items";
        private readonly IMongoCollection<Product> productCollection;
        private readonly FilterDefinitionBuilder<Product> filterBuilder = Builders<Product>.Filter;

        public MongoDBProductsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            productCollection = database.GetCollection<Product>(collectionName);
        }

        public async Task CreateItemAsync(Product item)
        {
            await productCollection.InsertOneAsync(item);
        }
        public async Task DeleteItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);
            await productCollection.DeleteOneAsync(filter);
        }

        public async Task<Product> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);
            return await productCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetItemsAsync()
        {
            return await productCollection.FindAsync(_ => true).Result.ToListAsync();
        }

        public async Task UpdateItemAsync(Product item)
        {
            var filter = filterBuilder.Eq(product => product.Id, item.Id);
            await productCollection.ReplaceOneAsync(filter, item);
        }
    }
}
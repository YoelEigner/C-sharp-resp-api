using Microsoft.AspNetCore.Mvc;
using Products.Dtos;
using Products.Models;
using Products.Repository;

namespace Products.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;
        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        //GET /api/products
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetItemsAsync()
        {
            return (await productsRepository.GetItemsAsync()).Select(item => item.AsDto());
        }
        //GET /api/products/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetItem(Guid id)
        {
            var item = await productsRepository.GetItemAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        //POST /api/products
        [HttpPost]

        public async Task<ActionResult<ProductDto>> CreateItemAsync(CreateProductDto productDto)
        {
            Product prod = new()
            {
                Id = Guid.NewGuid(),
                Name = productDto.Name,
                Quantity = productDto.Quantity,
                Price = productDto.Price
            };
            await productsRepository.CreateItemAsync(prod);
            return CreatedAtAction(nameof(GetItem), new { id = prod.Id }, prod.AsDto());

        }
        //PUT /api/products/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateItemAsync(Guid id, UpdateProductDto productDto)
        {
            var existingItem = await productsRepository.GetItemAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            Product product = existingItem with
            {
                Price = productDto.Price,
                Quantity = productDto.Quantity,
            };
            await productsRepository.UpdateItemAsync(product);
            return NoContent();
        }

        //DELETE /api/products/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var existingItem = await productsRepository.GetItemAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            await productsRepository.DeleteItemAsync(id);
            return NoContent();
        }
    }
}
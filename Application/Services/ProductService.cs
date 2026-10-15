using Application.Dto;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductServices
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Marca = product.Marca,
                Price = product.Price
            };
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Marca = p.Marca,
                Price = p.Price
            }).ToList();
        }

        public async Task AddAsync(CreateProductDto productDto)
        {
            var product = new Domain.Entities.Product
            {
                Name = productDto.Name,
                Marca = productDto.Marca,
                Price = productDto.Price
            };
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByIdAsync(productDto.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }
            existingProduct.Name = productDto.Name;
            existingProduct.Marca = productDto.Marca;
            existingProduct.Price = productDto.Price;
            
            await _productRepository.UpdateAsync(existingProduct, existingProduct.Id);
        }

        public async Task DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }
            
            await _productRepository.DeleteAsync(id);
        }
    }
}
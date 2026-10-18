using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductController(IProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CreateProductDto productDto)
        {
            await _productService.AddAsync(productDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                return BadRequest();
            }
            await _productService.UpdateAsync(productDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productService.DeleteAsync(id);
            return Ok();
        }

        
    }
}
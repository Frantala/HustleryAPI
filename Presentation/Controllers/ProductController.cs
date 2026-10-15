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
        public ActionResult GetAll()
        {
            var products = _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult Add(CreateProductDto productDto)
        {
            _productService.AddAsync(productDto);
            return Ok();
        }
    }
}
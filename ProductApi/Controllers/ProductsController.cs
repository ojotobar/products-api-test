using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs;
using ProductApi.Models.Enums;
using ProductApi.Services.Interfaces;

namespace ProductApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductCategory? category, string? name)
        {
            _logger.LogInformation("Getting list of products...");
            var products = _service.GetAll(category, name);

            _logger.LogInformation($"Retrieved {products.Count} products...");

            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                _logger.LogError($"No product found for Id: {id}");
                return NotFound();
            }

            return Ok(product);
        }

       //POST: api/products
       [HttpPost]
        public IActionResult Post(ProductRequest request)
        {
            _logger.LogInformation($"Request products creation: {request.Name}");
            var product = _service.Add(request);
            if (product == null)
            {
                _logger.LogError("An error occurred while adding product");
                return BadRequest();
            }

            _logger.LogInformation($"Product successfully added: {request.Name}");

            return Created();
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, ProductRequest request)
        {
            var isSuccess = _service.Update(id, request);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return NoContent();
        }

        //PUT: api/products/{id }
        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] int id, ProductRequest request)
        {
            _logger.LogWarning($"Attempting to update product: {id}");
            var isSuccess = _service.Update(id, request);
            if (!isSuccess)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogCritical($"Attempting to delete product: {id}");

            var isDelete = _service.Delete(id);
            if (!isDelete)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TecnoFood.Data;
using TecnoFood.Models;
using TecnoFood.Commands.Product;

namespace TecnoFood.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] CreateProductCommand command)
        {
            Product product = new(command);
            _context.Products.Add(product);
            _context.SaveChanges();

            return CreatedAtAction(nameof(AddProduct),
                new { id = product.Id },
                product);
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductPorId(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id.Equals(id));
            if (product == null) return NotFound();
            
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, [FromBody] UpdateProductCommand command)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();

            product.Update(command);
            _context.Products.Update(product);

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            
            _context.Remove(product);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}

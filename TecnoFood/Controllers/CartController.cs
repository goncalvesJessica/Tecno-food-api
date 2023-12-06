using Microsoft.AspNetCore.Mvc;
using TecnoFood.Data;
using TecnoFood.Models;
using TecnoFood.Commands.Cart;
using Microsoft.EntityFrameworkCore;
using TecnoFood.Services;
using Microsoft.AspNetCore.Authorization;

namespace TecnoFood.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class CartController : ControllerBase
    {
        private readonly Context _context;
        private readonly CartService _service;

        public CartController(Context context)
        {
            _context = context;
            _service = new(context);
        }

        [HttpPost]
        public IActionResult AddCart([FromBody] CreateCartCommand command)
        {
            var domain = _service.CreateCart(command);
            return Ok(new { id = domain.Id });
        }

        [HttpGet]
        public IEnumerable<Cart> GetCarts()
        {
            return _context.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product);
        }

        [HttpGet("{id}")]
        public IActionResult GetCartById(int id)
        {
            var Cart = _context.Carts.Include(x => x.CartItems).ThenInclude(x => x.Product).FirstOrDefault(x => x.Id.Equals(id));
            if (Cart == null) return NotFound();

            return Ok(Cart);
        }
    }
}

using TecnoFood.Commands.Cart;
using TecnoFood.Data;
using TecnoFood.Models;

namespace TecnoFood.Services
{
    public class CartService
    {
        private readonly Context _context;

        public CartService(Context context)
        {
            _context = context;
        }

        public Cart CreateCart(CreateCartCommand command)
        {
            var domain = new Cart();
            var domainItem = new List<CartItem>();

            foreach (var item in command.Products)
            {
                var product = _context.Products.FirstOrDefault(x => x.Id.Equals(item.ProductId));
                domainItem.Add(new CartItem { Product = product, Quantity = item.Quantity, });
            }

            domain.AddUser(command.UserId);
            domain.AddCartItem(domainItem);
            domain.SetTotalValue();

            _context.Carts.Add(domain);
            _context.SaveChanges();

            return domain;
        }
    }
}

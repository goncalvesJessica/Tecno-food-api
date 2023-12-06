using System.ComponentModel.DataAnnotations;

namespace TecnoFood.Models
{
    public class Cart
    {
        public Cart()
        {

        }

        public int Id { get; internal set; }

        [Required(ErrorMessage = "O usuario deve ser informado")]
        public int UserId { get; set; }

        public virtual List<CartItem> CartItems { get; set; } = new();

        [Required(ErrorMessage = "O valor total nao foi calculado corretamente")]
        public decimal TotalValue { get; set; }

        public DateTime Registration { get; set; } = DateTime.Now;

        public void AddUser(int userId)
        {
            UserId = userId;
        }

        public void AddCartItem(List<CartItem> item)
        {
            CartItems.AddRange(item);
        }

        public void SetTotalValue()
        {
            double totalValue = 0;

            foreach (var item in CartItems)
                totalValue += item.Quantity * item.Product.Value;

            TotalValue = (decimal)totalValue;
        }
    }
}

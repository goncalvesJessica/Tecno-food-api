using System.ComponentModel.DataAnnotations;

namespace TecnoFood.Models
{
    public class CartItem
    {
        public CartItem()
        {
                
        }

        public int Id { get; internal set; }

        [Required(ErrorMessage = "Quantidade de produto obrigatoria")]
        public int Quantity { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public DateTime Registration { get; set; } = DateTime.Now;
    }
}

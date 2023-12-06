using System.ComponentModel.DataAnnotations;

namespace TecnoFood.Commands.Cart;

public class CreateCartCommand
{
    [Required(ErrorMessage = "O usuario deve ser informado")]
    public int UserId { get; set; }

    public List<CreateCartCommandItem> Products { get; set; }
}

public class CreateCartCommandItem
{
    [Required(ErrorMessage = "O produto deve ser informado")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "A quantidade do Product é obrigatório")]
    [Range(1, 100, ErrorMessage = "A quantidade de Products deve ter entre 1 e 100 unidades")]
    public int Quantity { get; set; }
}

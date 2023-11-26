using System.ComponentModel.DataAnnotations;
using TecnoFood.Commands.Product;

namespace TecnoFood.Models;

public class Product
{
    public Product()
    {

    }

    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Category = command.Category;
        Quantity = command.Quantity;
        Value = command.Value;
    }

    public int Id { get; internal set; }

    [Required(ErrorMessage = "O nome do Product é obrigatório")]
    [MaxLength(20, ErrorMessage = "O tamanho do Product não pode exeder 20 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A descrição do Product é obrigatório")]
    [MaxLength(100, ErrorMessage = "O tamanho da descrição não pode exeder 100 caracteres")]
    public string Description { get; set; }


    [Required(ErrorMessage = "A categoria do Product é obrigatório")]
    [MaxLength(20, ErrorMessage = "O tamanho da categoria não pode exeder 20 caracteres")]
    public string Category { get; set; }

    [Required(ErrorMessage = "A quantidade do Product é obrigatório")]
    [Range(1, 100, ErrorMessage = "A quantidade de Products deve ter entre 1 e 100 unidades")]
    public int Quantity { get; set; }

    [Range(1, 100, ErrorMessage = "O valor do Products deve ter entre 1 e 100 reais")]
    [Required(ErrorMessage = "O valor do Product é obrigatório")]
    public double Value { get; set; }

    public DateTime Registration { get; set; } = DateTime.Now;

    public void Update(UpdateProductCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Category = command.Category;
        Quantity = command.Quantity;
        Value = command.Value;
    }
}

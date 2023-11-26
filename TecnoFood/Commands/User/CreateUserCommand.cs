using System.ComponentModel.DataAnnotations;

namespace TecnoFood.Commands.User;

public class CreateUserCommand
{
    public int Id { get; internal set; }

    [Required(ErrorMessage = "O nome é obrigatório")]
    [MaxLength(80, ErrorMessage = "O tamanho do nome não pode exeder 80 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O email é obrigatório")]
    [MaxLength(100, ErrorMessage = "O tamanho do email não pode exeder 100 caracteres")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O cpf é obrigatório")]
    [MaxLength(11, ErrorMessage = "O tamanho do cpf não pode exeder 11 caracteres")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O telephone é obrigatório")]
    [MaxLength(11, ErrorMessage = "O tamanho do telephone não pode exeder 11 caracteres")]
    public string Telephone { get; set; }

    [MaxLength(15)]
    [MinLength(8)]
    [Required(ErrorMessage = "A senha é obrigatório")]
    public string Password { get; set; }

    [MaxLength(100, ErrorMessage = "O tamanho do role não pode exeder 100 caracteres")]
    public string Role { get; set; }
}

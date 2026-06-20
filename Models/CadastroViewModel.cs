using System.ComponentModel.DataAnnotations;

namespace Compraí____Listas_compartilhadas.Models
{
    public class CadastroViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [MinLength(6, ErrorMessage = "Mínima de 6 caracteres")]
        public string Senha { get; set; }

    }
}
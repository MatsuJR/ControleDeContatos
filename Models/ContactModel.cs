using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o numero de celular do contato")]
        [Phone(ErrorMessage = "O numero informado não é valido")]
        public string Phone { get; set; }

    }
}

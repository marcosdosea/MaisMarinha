using System.ComponentModel.DataAnnotations;

namespace MaisMarinhaWeb.Models
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Nome requerido")]
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage ="O campo aceita até 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF requerido")]
        [RegularExpression(@"([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Email requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Estado requerido")]
        [Display(Name = "Estado")]
        [StringLength(2, MinimumLength = 2)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo Cidade requerido")]
        [Display(Name = "Cidade")]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Bairro requerido")]
        [Display(Name = "Bairro")]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Rua requerido")]
        [Display(Name = "Rua")]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Numero da residência")]
        [StringLength(15, ErrorMessage = "Numero da residência tem entre 1 e 15 digitos", MinimumLength = 1)]
        public string NumeroEndereco { get; set; }

        [Display(Name = "CEP")]
        [DataType(DataType.PostalCode)]
        public string Cep { get; set; }

        [Display(Name = "Complemento do endereço")]
        [StringLength(100, ErrorMessage = "O campo aceita até 100 caracteres")]
        public string Complemento { get; set; }

        [Display(Name = "Número de telefone")]
        [RegularExpression(@"^(\([1-9]{2}\)|[1-9]{2}) ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Exemplo de numero de telefone: (79)99999-9999")]
        public string Telefone { get; set; }
    }
}

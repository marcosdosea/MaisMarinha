using System.ComponentModel.DataAnnotations;

namespace MaisMarinhaWeb.Models
{
    public class CapitaniaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é requerido")]
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "O campo aceita até 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Estado é requerido")]
        [Display(Name = "Estado")]
        [DataType(DataType.Text)]
        [StringLength(2, ErrorMessage = "O campo aceita até 2 caracteres")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo Cidade é requerido")]
        [Display(Name = "Cidade")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo Bairro é requerido")]
        [Display(Name = "Bairro")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo Rua é requerido")]
        [Display(Name = "Rua")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Campo Número é requerido")]
        [Display(Name = "Número")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Campo MetareaV é requerido")]
        [Display(Name = "MetareaV")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "O campo aceita até 100 caracteres")]
        public string MetareaV { get; set; }

        [Display(Name = "Telefone")]
        [RegularExpression(@"^(\([1-9]{2}\)|[1-9]{2}) ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Exemplo de numero de telefone: (79)99999-9999")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Hora Inicio é requerido")]
        [Display(Name = "Hora de Inicio")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public DateTime HoraInicio { get; set; }

        [Required(ErrorMessage = "Campo Hora Fim é requerido")]
        [Display(Name = "Hora Final")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public DateTime HoraFim { get; set; }

    }
}

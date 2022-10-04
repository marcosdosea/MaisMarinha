using System.ComponentModel.DataAnnotations;

namespace MaisMarinhaWeb.Models
{
    public class CursoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome requerido")]
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "O campo aceita até 100 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Campo Data Inicial é requerido")]
        [Display(Name = "Data Inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicial { get; set; }

        [Required(ErrorMessage = "Campo Data Final é requerido")]
        [Display(Name = "Data Final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "Campo Quantidade de Vagas é requerido")]
        [Display(Name = "Quantidade de Vagas")]
        public int QuantidadeVagas { get; set; }

        [Required(ErrorMessage = "Campo Estado é requerido")]
        [Display(Name = "Estado")]
        [DataType(DataType.Text)]
        [StringLength(2, ErrorMessage = "O campo aceita até 2 caracteres")]
        public string? Estado { get; set; }

        [Required(ErrorMessage = "Campo Cidade é requerido")]
        [Display(Name = "Cidade")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string? Cidade { get; set; }

        [Required(ErrorMessage = "Campo Requisitos é requerido")]
        [Display(Name = "Requisitos")]
        [DataType(DataType.Text)]
        [StringLength(200, ErrorMessage = "O campo aceita até 200 caracteres")]
        public string? Requisitos { get; set; }

        [Required(ErrorMessage = "Campo Data Inicial de Inscrição é requerido")]
        [Display(Name = "Data Inicial de Inscrição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInicioInscricao { get; set; }

        [Required(ErrorMessage = "Campo Data Final de Inscrição é requerido")]
        [Display(Name = "Data Final de Inscrição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataFimInscricao { get; set; }

        [Required(ErrorMessage = "Campo Duração é requerido")]
        [Display(Name = "Duração do Curso")]
        [DataType(DataType.Text)]
        [StringLength(150, ErrorMessage = "O campo aceita até 150 caracteres")]
        public string? Duracao { get; set; }

        public int IdCapitania { get; set; }
    }
}

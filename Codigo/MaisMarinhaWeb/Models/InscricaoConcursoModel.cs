using Core;
using System.ComponentModel.DataAnnotations;

namespace MaisMarinhaWeb.Models
{
    public class InscricaoConcursoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O número referente ao concurso é requerido")]
        public int IdConcurso { get; set; }

        [Required(ErrorMessage = "O número referente a pessoa é requerido")]
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Campo Status é requerido")]
        [Display(Name = "Status")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Campo Data Inscrição é requerido")]
        [Display(Name = "Data da Inscrição")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataInscricao { get; set; }

    }
}

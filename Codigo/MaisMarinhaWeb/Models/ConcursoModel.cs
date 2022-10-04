using System.ComponentModel.DataAnnotations;

namespace MaisMarinhaWeb.Models
{
    public class ConcursoModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Nome é requerido")]
        [Display(Name = "Nome")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "O campo aceita até 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Edital é requerido")]
        [Display(Name = "Edital")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public int Edital { get; set; }

        [Required(ErrorMessage = "Campo Data Inicial é requerido")]
        [Display(Name = "Data Inicial")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public DateTime DataInicialInscricao { get; set; }

        [Required(ErrorMessage = "Campo Data Final é requerido")]
        [Display(Name = "Data Final")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public DateTime DataFinalInscricao { get; set; }

        [Required(ErrorMessage = "Campo Data Da Prova é requerido")]
        [Display(Name = "Data Da Prova")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public DateTime DataProva { get; set; }

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

        [Required(ErrorMessage = "Campo Vagas é requerido")]
        [Display(Name = "Vagas")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public int Vagas { get; set; }

        [Required(ErrorMessage = "Campo Escolaridade é requerido")]
        [Display(Name = "Escolaridade")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Escolaridade { get; set; }

        [Required(ErrorMessage = "Campo Etapas é requerido")]
        [Display(Name = "Etapas")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string Etapas { get; set; }

        [Required(ErrorMessage = "Campo Área técnica é requerido")]
        [Display(Name = "Área técnica")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "O campo aceita até 50 caracteres")]
        public string AreaTecnica { get; set; }

        [Required(ErrorMessage = "Campo Local Inscrição é requerido")]
        [Display(Name = "Local Inscrição")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "O campo aceita até 100 caracteres")]
        public string LocalInscricao { get; set; }

        [Required(ErrorMessage = "Campo Valor Inscrição é requerido")]
        [Display(Name = "Valor Inscrição")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public float ValorInscricao { get; set; }

        [Required(ErrorMessage = "Campo Local Prova é requerido")]
        [Display(Name = "Local Prova")]
        [DataType(DataType.Text)]
        [StringLength(100, ErrorMessage = "O campo aceita até 100 caracteres")]
        public string LocalProva { get; set; }

        [Required(ErrorMessage = "Campo Cargo é requerido")]
        [Display(Name = "Cargo")]
        [DataType(DataType.Text)]
        [StringLength(60, ErrorMessage = "O campo aceita até 60 caracteres")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Campo Turma é requerido")]
        [Display(Name = "Turma")]
        [DataType(DataType.Text)]
        [StringLength(10, ErrorMessage = "O campo aceita até 10 caracteres")]
        public string Turma { get; set; }
    }
}

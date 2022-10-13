using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class InscricaoCurso
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public int IdCurso { get; set; }
        public string Status { get; set; }
        public DateTime DataInscricao { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Inscricaoconcurso
    {
        public int IdConcurso { get; set; }
        public int IdPessoa { get; set; }
        public string Status { get; set; }
        public DateTime DataInscricao { get; set; }

        public virtual Concurso IdConcursoNavigation { get; set; }
        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}

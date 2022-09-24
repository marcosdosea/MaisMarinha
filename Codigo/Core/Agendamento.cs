using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Agendamento
    {
        public int Id { get; set; }
        public string TipoAtendimento { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public int IdPessoa { get; set; }
        public int IdServico { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; }
    }
}

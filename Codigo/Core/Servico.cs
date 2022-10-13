using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Servico
    {
        public Servico()
        {
            Agendamentos = new HashSet<Agendamento>();
            Agendaservicos = new HashSet<Agendaservico>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdCapitania { get; set; }

        public virtual Capitania IdCapitaniaNavigation { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Agendaservico> Agendaservicos { get; set; }
    }
}

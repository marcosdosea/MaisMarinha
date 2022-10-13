using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Agendaservico
    {
        public int Id { get; set; }
        public DateTime DiaSemana { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public int Vagas { get; set; }
        public int IdServico { get; set; }

        public virtual Servico IdServicoNavigation { get; set; }
    }
}

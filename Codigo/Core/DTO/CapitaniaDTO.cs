using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    internal class CapitaniaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string MetareaV { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }

    }
}

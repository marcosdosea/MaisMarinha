using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    internal class CursoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadeVagas { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public DateTime DataInicioInscricao { get; set; }
        public DateTime DataFimInscricao { get; set; }
    }
}

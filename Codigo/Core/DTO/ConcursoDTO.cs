using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ConcursoDTO
    {
        public int Id { get; set; }
        public String? Nome { get; set; }
        public DateTime DataInicialInscricao { get; set; }
        public DateTime DataFinalInscricao { get; set; }
        public DateTime DataProva { get; set; }
        public String? Escolaridade { get; set; }
    }
}

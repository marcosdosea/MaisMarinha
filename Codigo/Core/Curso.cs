using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Curso
    {
        public Curso()
        {
            Inscricaocursos = new HashSet<Inscricaocurso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFim { get; set; }
        public int QuantidadeVagas { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Requisitos { get; set; }
        public DateTime DataInicioInscricao { get; set; }
        public DateTime DataFimInscricao { get; set; }
        public string Duracao { get; set; }
        public int IdCapitania { get; set; }

        public virtual ICollection<Inscricaocurso> Inscricaocursos { get; set; }
    }
}

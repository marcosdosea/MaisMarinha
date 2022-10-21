using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Concurso
    {
        public Concurso()
        {
            Capitaniaconcursos = new HashSet<Capitaniaconcurso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Edital { get; set; }
        public DateTime DataInicialInscricao { get; set; }
        public DateTime DataFinalInscricao { get; set; }
        public DateTime DataProva { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public int Vagas { get; set; }
        public string Escolaridade { get; set; }
        public string Etapas { get; set; }
        public string AreaTecnica { get; set; }
        public string LocalInscricao { get; set; }
        public float ValorInscricao { get; set; }
        public string LocalProva { get; set; }
        public string Cargo { get; set; }
        public string Turma { get; set; }

        public virtual ICollection<Capitaniaconcurso> Capitaniaconcursos { get; set; }
        public virtual ICollection<Inscricaoconcurso> Inscricaoconcursos { get; set; }
    }
}

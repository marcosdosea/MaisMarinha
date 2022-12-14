using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Capitania
    {
        public Capitania()
        {
            Capitaniaconcursos = new HashSet<Capitaniaconcurso>();
            Climas = new HashSet<Clima>();
            Cursos = new HashSet<Curso>();
            Servicos = new HashSet<Servico>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string MetareaV { get; set; }
        public string Telefone { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }

        public virtual ICollection<Capitaniaconcurso> Capitaniaconcursos { get; set; }
        public virtual ICollection<Clima> Climas { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Servico> Servicos { get; set; }
    }
}

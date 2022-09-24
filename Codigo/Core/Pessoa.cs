using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Agendamentos = new HashSet<Agendamento>();
            Inscricaoconcursos = new HashSet<Inscricaoconcurso>();
            Inscricaocursos = new HashSet<Inscricaocurso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string NumeroEndereco { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Inscricaoconcurso> Inscricaoconcursos { get; set; }
        public virtual ICollection<Inscricaocurso> Inscricaocursos { get; set; }
    }
}

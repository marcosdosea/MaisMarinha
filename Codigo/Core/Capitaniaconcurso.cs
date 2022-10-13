using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Capitaniaconcurso
    {
        public int Id { get; set; }
        public int IdCapitania { get; set; }
        public int IdConcurso { get; set; }
        public string CapitaniaConcursocol { get; set; }

        public virtual Capitania IdCapitaniaNavigation { get; set; }
        public virtual Concurso IdConcursoNavigation { get; set; }
    }
}

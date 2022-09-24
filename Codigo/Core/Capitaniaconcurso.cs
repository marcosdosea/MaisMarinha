using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Capitaniaconcurso
    {
        public int IdCapitania { get; set; }
        public int IdConcurso { get; set; }

        public virtual Capitanium IdCapitaniaNavigation { get; set; }
        public virtual Concurso IdConcursoNavigation { get; set; }
    }
}

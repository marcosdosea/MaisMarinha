using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdCapitania { get; set; }
    }
}

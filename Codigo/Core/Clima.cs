using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Clima
    {
        public int Id { get; set; }
        public string MetareaV { get; set; }
        public string AlertaMar { get; set; }
        public string AlertaVento { get; set; }
        public string DescricaoAlertaMar { get; set; }
        public string DescricaoAlertaVento { get; set; }
        public string Coordenadas { get; set; }
        public DateTime HoraEmissao { get; set; }
        public DateTime Validade { get; set; }
        public int IdCapitania { get; set; }

        public virtual Capitania IdCapitaniaNavigation { get; set; }
    }
}

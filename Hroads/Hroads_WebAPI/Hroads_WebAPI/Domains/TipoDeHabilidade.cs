using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads_WebAPI.Domains
{
    public partial class TipoDeHabilidade
    {
        public TipoDeHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoDeHabilidade { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}

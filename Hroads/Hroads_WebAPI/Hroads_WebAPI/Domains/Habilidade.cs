using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads_WebAPI.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            Classes = new HashSet<Class>();
        }

        public int IdHabilidade { get; set; }
        public int? IdTipoDeHabilidade { get; set; }
        public string Nome { get; set; }

        public virtual TipoDeHabilidade IdTipoDeHabilidadeNavigation { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}

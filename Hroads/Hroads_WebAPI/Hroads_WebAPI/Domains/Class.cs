using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads_WebAPI.Domains
{
    public partial class Class
    {
        public Class()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public int? IdHabilidade { get; set; }
        public string NomeClasse { get; set; }

        public virtual Habilidade IdHabilidadeNavigation { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}

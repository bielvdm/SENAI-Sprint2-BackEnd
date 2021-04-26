using System;
using System.Collections.Generic;

#nullable disable

namespace Hroads_WebAPI.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public int? IdClasse { get; set; }
        public string NomePersonagem { get; set; }
        public int CapacidadeVida { get; set; }
        public int CapacidadeMana { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualização { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}

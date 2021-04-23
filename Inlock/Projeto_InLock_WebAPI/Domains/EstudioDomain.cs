using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }
        public string NomeEstudio { get; set; }
        public JogosDomain jogo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Domains
{
    public class JogosDomain
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public float Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public int IdEstudio { get; set; }
        public EstudioDomain estudio { get; set; } //aqui serve p fazer a juncao da tabela estudio com jogos
    }
}

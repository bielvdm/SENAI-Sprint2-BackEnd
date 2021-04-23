using Projeto_InLock_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Interfaces
{
    interface IEstudioRepository
    {
        public List<EstudioDomain> BuscarJogo();
    }
}

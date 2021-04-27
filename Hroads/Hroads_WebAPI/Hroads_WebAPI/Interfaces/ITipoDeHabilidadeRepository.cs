using Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Interfaces
{
    interface ITipoDeHabilidadeRepository
    {
        //crud

        List<TipoDeHabilidade> Listar();

        void Cadastro(TipoDeHabilidade Nome);

        void Deletar(int id);

        void Atualizar(TipoDeHabilidade Nome, int id);

        TipoDeHabilidade BuscarPorId(int id);
    }
}

using Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Interfaces
{
    interface IHabilidadeRepository
    {
        List<Habilidade> Listar();

        void Cadastro(Habilidade Nome);

        void Deletar(int id);

        void Atualizar(Habilidade Nome, int id);

        Habilidade BuscarPorId(int id);
    }
}

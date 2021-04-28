using Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Interfaces
{
    interface IPersonagemRepository
    {
        //crud

        List<Personagem> Listar();
        List<Personagem> ListarComClasse();

        void Cadastro(Personagem Nome);

        void Deletar(int id);

        void Atualizar(Personagem Nome, int id);

        Personagem BuscarPorId(int id);
    }
}

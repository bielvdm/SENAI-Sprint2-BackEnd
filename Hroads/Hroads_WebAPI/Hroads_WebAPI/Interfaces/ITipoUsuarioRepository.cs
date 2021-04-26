using Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Interfaces
{
    interface ITipoUsuarioRepository
    {
        //crud

        List<TipoUsuario> Listar();

        void Cadastro(TipoUsuario Nome);

        void Deletar(int id);

        void Atualizar(TipoUsuario Nome, int id);

        TipoUsuario BuscarPorId(int id);

    }
}

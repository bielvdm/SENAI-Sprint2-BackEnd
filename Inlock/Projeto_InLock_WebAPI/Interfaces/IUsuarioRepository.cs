using Projeto_InLock_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Interfaces
{
    interface IUsuarioRepository
    {
        void CadastrarUsuario(UsuarioDomain NovoUsuario);
        UsuarioDomain BuscarPorEmail(string Email, string Senha);
    }
}

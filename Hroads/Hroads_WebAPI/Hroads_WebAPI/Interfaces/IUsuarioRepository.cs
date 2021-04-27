using Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Interfaces
{
    interface IUsuarioRepository
    {
        //CRUD
        Usuario Login(string Email, string Senha);
        List<Usuario> Listar();
        
        void Cadastro(Usuario NovoUsuario);
        
        void Deletar(int id);
  
        void Atualizar(Usuario UsuarioAtualizado, int id);
       
        Usuario BuscarPorId(int id);
    }
}

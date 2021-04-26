using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SENAI_HROADS_TARDEContext ctx = new SENAI_HROADS_TARDEContext();

        public void Atualizar(TipoUsuario Nome, int id)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            if (Nome.Titulo != null)
            {
                TipoUsuarioBuscado.Titulo = Nome.Titulo;
            }

            ctx.TipoUsuarios.Update(TipoUsuarioBuscado);

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(u => u.IdTipoUsuario == id);
        }

        public void Cadastro(TipoUsuario Nome)
        {
            //adiciona pelo parametro nome
            ctx.TipoUsuarios.Add(Nome);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //instancia um novo tipo usuario para buscar pelo id
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuarios.Find(id);

            //aqui ele remove o usuario buscado lá em cima
            ctx.TipoUsuarios.Remove(TipoUsuarioBuscado);

            //salva as alterações
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}

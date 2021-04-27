using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Repositories
{
    public class TipoDeHabilidadeRepository : ITipoDeHabilidadeRepository
    {
        SENAI_HROADS_TARDEContext ctx = new SENAI_HROADS_TARDEContext();

        public void Atualizar(TipoDeHabilidade Nome, int id)
        {
            TipoDeHabilidade habilidadeBuscada = ctx.TipoDeHabilidades.Find(id);
            if (Nome.NomeTipo != null)
            {
                habilidadeBuscada.NomeTipo = Nome.NomeTipo;
            }

            ctx.TipoDeHabilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public TipoDeHabilidade BuscarPorId(int id)
        {
            return ctx.TipoDeHabilidades.FirstOrDefault(h => h.IdTipoDeHabilidade == id);
        }

        public void Cadastro(TipoDeHabilidade Nome)
        {
            ctx.TipoDeHabilidades.Add(Nome);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            TipoDeHabilidade habilidadeBuscada = ctx.TipoDeHabilidades.Find(id);

            ctx.TipoDeHabilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<TipoDeHabilidade> Listar()
        {
            return ctx.TipoDeHabilidades.ToList();
        }
    }
}

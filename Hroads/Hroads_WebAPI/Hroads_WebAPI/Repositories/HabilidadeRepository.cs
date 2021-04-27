using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        SENAI_HROADS_TARDEContext ctx = new SENAI_HROADS_TARDEContext();
        public void Atualizar(Habilidade Nome, int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            if (Nome.Nome != null)
            {
                habilidadeBuscada.Nome = Nome.Nome;
                habilidadeBuscada.IdTipoDeHabilidade = Nome.IdTipoDeHabilidade;
            }

            ctx.Habilidades.Update(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public Habilidade BuscarPorId(int id)
        {
            return ctx.Habilidades.FirstOrDefault(h => h.IdHabilidade == id);
        }

        public void Cadastro(Habilidade Nome)
        {
            ctx.Habilidades.Add(Nome);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Habilidade habilidadeBuscada = ctx.Habilidades.Find(id);

            ctx.Habilidades.Remove(habilidadeBuscada);

            ctx.SaveChanges();
        }

        public List<Habilidade> Listar()
        {
            return ctx.Habilidades.ToList();
        }
    }
}

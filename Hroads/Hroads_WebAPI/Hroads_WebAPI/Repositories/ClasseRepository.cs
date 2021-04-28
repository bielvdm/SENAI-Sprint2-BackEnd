using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        SENAI_HROADS_TARDEContext ctx = new SENAI_HROADS_TARDEContext();

        public void Atualizar(Class Nome, int id)
        {
            Class classeBuscada = ctx.Classes.Find(id);

            if (Nome.NomeClasse != null)
            {
                classeBuscada.NomeClasse = Nome.NomeClasse;
                classeBuscada.IdHabilidade = Nome.IdHabilidade;
            }

            ctx.Classes.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public Class BuscarPorId(int id)
        {
            return ctx.Classes.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastro(Class Nome)
        {
            ctx.Classes.Add(Nome);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Class classeBuscada = ctx.Classes.Find(id);

            ctx.Classes.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// /ele lista em ordem alfabetica tah
        /// </summary>
        /// <returns></returns>
        public List<Class> Listar()
        {
            return ctx.Classes.OrderBy(c => c.NomeClasse).ToList();
        }
    }
}

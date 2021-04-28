using Hroads_WebAPI.Domains;
using Hroads_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Repositories
{
    public class ClasseHabilidadeRepository : IClasseHabilidadeRepository
    {
        SENAI_HROADS_TARDEContext ctx = new SENAI_HROADS_TARDEContext();
        public void Atualizar(int id, ClassesHabilidade Nome)
        {
            ClassesHabilidade classeBuscada = ctx.ClassesHabilidades.Find(id);

            if(Nome.IdClasse != null)
            {
                classeBuscada.IdClasse = Nome.IdClasse;
                classeBuscada.IdHabilidade = Nome.IdHabilidade;
            }

            ctx.ClassesHabilidades.Update(classeBuscada);

            ctx.SaveChanges();
        }

        public ClassesHabilidade BuscarPorId(int id)
        {
            return ctx.ClassesHabilidades.FirstOrDefault(c => c.IdClasse == id);
        }

        public void Cadastro(ClassesHabilidade Nome)
        {
            ctx.ClassesHabilidades.Add(Nome);
        }

        public void Deletar(int id)
        {
            ClassesHabilidade classeBuscada = ctx.ClassesHabilidades.Find(id);

            ctx.ClassesHabilidades.Remove(classeBuscada);

            ctx.SaveChanges();
        }

        public List<ClassesHabilidade> Listar()
        {
            return ctx.ClassesHabilidades.ToList();
        }
    }
}

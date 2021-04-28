using Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Interfaces
{
    interface IClasseHabilidadeRepository
    {
        List<ClassesHabilidade> Listar();
        void Cadastro(ClassesHabilidade Nome);
        void Deletar(int id);
        void Atualizar(int id, ClassesHabilidade Nome);
        ClassesHabilidade BuscarPorId(int id);
    }
}

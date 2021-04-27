using Hroads_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads_WebAPI.Interfaces
{
    interface IClasseRepository
    {
        List<Class> Listar();

        void Cadastro(Class Nome);

        void Deletar(int id);

        void Atualizar(Class Nome, int id);

        Class BuscarPorId(int id);
    }
}

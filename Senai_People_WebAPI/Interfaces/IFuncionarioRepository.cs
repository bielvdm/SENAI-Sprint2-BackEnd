using SENAI_People_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_People_WebAPI.Interfaces
{
    interface IFuncionarioRepository
    {
        //Crud
        List <FuncionarioDomain> ListarTodos ();

        FuncionarioDomain BuscarPorId (int Id);

        void Deletar(int id);

        void InserirNovo(FuncionarioDomain NomeFuncionario, FuncionarioDomain SobrenomeFuncionario);

        void Atualizar(FuncionarioDomain NomeFuncionario, FuncionarioDomain SobrenomeFuncionario);
    }
}

using People.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Interfaces
{
    interface IFuncionarioRepository
    {
        //Crud
        List<FuncionarioDomain> ListarTodos();

        FuncionarioDomain BuscarPorId(int Id);

        void Deletar(int id);

        void InserirNovo(FuncionarioDomain NovoNome);

        void Atualizar(FuncionarioDomain Nome);

        void AtualizarURL(int id, FuncionarioDomain Nome);

        void AtualizarUnico(string Nome, FuncionarioDomain Name);
    }
}

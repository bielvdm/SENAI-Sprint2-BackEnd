using Senai_Filmes_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Interfaces
{
    interface IFilmesRepository
    {
        /// <summary>
        /// aqui nós vamos adicionar um novo filme
        /// </summary>
        /// <param name="NomeFilme">adicionar o nome</param>
        void Cadastrar(FilmeDomain NomeFilme);

        /// <summary>
        /// aqui vamos listar todos os filmes
        /// </summary>
        /// <returns>vai retornar o nome dos filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// aqui vamos buscar e retornar o filme buscado
        /// </summary>
        /// <param name="id">serve pra buscar o filme pelo seu id</param>
        /// <returns>vai retornar o nome do filme e o genero</returns>
        FilmeDomain BuscarFilmePeloId(int id);

        void AtualizarFilmePeloId(int id, FilmeDomain filme);

        void AtualizarFilmePeloCorpo(FilmeDomain filme);

        void DeletarFilme(int id);
    }
}

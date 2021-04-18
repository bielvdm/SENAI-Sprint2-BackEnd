using Senai_Filmes_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Interfaces
{
    interface IGeneroRepository
    {
        /// <summary>
        /// Aqui serve para listar todos os itens, ele vai exibis os itens na tela
        /// </summary>
        /// <returns>vai retornar todos os itens generos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Aqui serve p vc buscar e listar apenas um genero
        /// </summary>
        /// <param name="id"> esse aqui é pra saber qual será o genero, de acordo com o id</param>
        /// <returns> vai retornar o genero escolhido de acordo com o id </returns>
        GeneroDomain BuscarId(int id);

        /// <summary>
        /// Aqui vai cadastrar um novo genero
        /// </summary>
        /// <param name="NomeGenero"> esse paramentro serve para sabermos o nome do genero novo q será cadastrado</param>
        void Cadastrar(GeneroDomain NomeGenero);

        /// <summary>
        /// aqui vai atualizar pelo id na url
        /// </summary>
        /// <param name="id">ele vai identificar o id</param>
        void AtualizarPeloId(int id, GeneroDomain genero);

        /// <summary>
        /// aqui vai atualizar pelo corpo, ou seja, vai buscar o nome que está lá
        /// </summary>
        /// <param name="genero"></param>
        void AtualizarCorpo(GeneroDomain genero);

        /// <summary>
        /// vai deletar o genero
        /// </summary>
        /// <param name="id">identifica o id q será deletado</param>
        void Deletar(int id);
    }
}

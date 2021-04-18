using Senai_Filmes_WebApi.Domains;
using Senai_Filmes_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source = DESKTOP-SL5KKOH; initial catalog = Filmes; integrated security = true";
        public void AtualizarCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarPeloId(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain NomeGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            //criar uma lista para armazenar todos os dados que vamos listar
            List<GeneroDomain> generos = new List<GeneroDomain>();

            //cria um using para fazer a conexao com o banco de dados
            using (SqlConnection conection = new SqlConnection (StringConexao) )
            {
                //string query para escrever o comando que queremos fazer no banco de dados
                string queryListar = "SELECT IdGenero, Nome FROM Generos";

                //aqui vai clicar no connect do banco de dadosd
                conection.Open();

                //variável que le os arquivos sql
                SqlDataReader reader;  

                //using para fazer o comando que escrevemos na query e a conexao com o banco de dados
                using (SqlCommand comando = new SqlCommand(queryListar, conection))
                {
                    //aqui ele vai executar o comando com os arquivos sql, através da variavel criada
                    reader = comando.ExecuteReader();

                    //esse while vai LER todos os itens que foram executados no reader
                    while (reader.Read())
                    {
                        //instancioamos um objeto para representar os valores que foram solicitados na query
                        GeneroDomain generoObj = new GeneroDomain() 
                        { 
                            //aqui são os values, mas como nao estao em formato sql, precisamos converter
                            IdGenero = Convert.ToInt32(reader[0]), 
                            Nome = reader[1].ToString()
                        };

                        //vamos adicionar o objeto na lista criada acime
                        generos.Add(generoObj);
                    }

                    //retornamos a lista para fazer a listagem
                    return generos;
                }
            }
        }
    }
}

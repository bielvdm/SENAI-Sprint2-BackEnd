using People.Domains;
using People.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace People.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringconexao = "Data Source = DESKTOP-SL5KKOH; initial catalog = People; integrated security = true";
        public void Atualizar(FuncionarioDomain Nome)
        {
            using (SqlConnection conexao = new SqlConnection(stringconexao))
            {
                string queryAtualizar = ("UPDATE Funcionarios SET NomeFuncionario = @Nome, SobrenomeFuncionario = @Sobrenome , DatadeNascimento = @DataDeNascimento WHERE IdFuncionario = @Id");

                using (SqlCommand comando = new SqlCommand(queryAtualizar, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", Nome.IdFuncionario);
                    comando.Parameters.AddWithValue("@Nome", Nome.NomeFuncionario);
                    comando.Parameters.AddWithValue("@Sobrenome", Nome.SobrenomeFuncionario);
                    comando.Parameters.AddWithValue("@DataDeNascimento", Nome.DatadeNascimento);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarUnico(FuncionarioDomain Nome)
        {
            throw new NotImplementedException();
        }

        public void AtualizarURL(int id, FuncionarioDomain Nome)
        {
            using (SqlConnection conexao = new SqlConnection (stringconexao))
            {
                string queryAtualizarURL = ("UPDATE Funcionarios SET NomeFuncionario = @Nome, SobrenomeFuncionario = @Sobrenome , DatadeNascimento = @DataDeNascimento WHERE IdFuncionario = @Id");

                using (SqlCommand comando = new SqlCommand(queryAtualizarURL, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.Parameters.AddWithValue("@Nome", Nome.NomeFuncionario);
                    comando.Parameters.AddWithValue("@Sobrenome", Nome.SobrenomeFuncionario);
                    comando.Parameters.AddWithValue("@DataDeNascimento", Nome.DatadeNascimento);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int Id)
        {

            using (SqlConnection conexao = new SqlConnection(stringconexao))
            {
                string queryBuscar = ("SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario, DatadeNascimento FROM Funcionarios WHERE IdFuncionario = @ID");

                SqlDataReader reader;

                conexao.Open();

                using (SqlCommand comando = new SqlCommand(queryBuscar, conexao))
                {
                    comando.Parameters.AddWithValue("@ID", Id);

                    reader = comando.ExecuteReader();

                    if (reader.Read())
                    {
                        FuncionarioDomain objetoBuscar = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(reader[0]),
                            NomeFuncionario = reader[1].ToString(),
                            SobrenomeFuncionario = reader[2].ToString(),
                            DatadeNascimento = Convert.ToDateTime(reader[3])
                        };

                        return objetoBuscar;
                    }

                    return null;
                }

            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection(stringconexao))
            {
                string queryDeletar = ("DELETE FROM Funcionarios WHERE IdFuncionario = @ID");

                using (SqlCommand comando = new SqlCommand(queryDeletar, conexao))
                {

                    comando.Parameters.AddWithValue("@ID", id);

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void InserirNovo(FuncionarioDomain NovoNome)
        {
            using (SqlConnection conexao = new SqlConnection(stringconexao))
            {
                string QueryCadastro = ("INSERT INTO Funcionarios VALUES (@NomeFuncionario, @SobrenomeFuncionario, @DataDeNascimento)");

                //executamos o comando que tem relaçao com a query e o banco de dados
                using (SqlCommand comando = new SqlCommand(QueryCadastro, conexao))
                {

                    //esses parametros with value evitam aquele efeito joana darc
                    comando.Parameters.AddWithValue("@NomeFuncionario", NovoNome.NomeFuncionario);
                    comando.Parameters.AddWithValue("@SobrenomeFuncionario", NovoNome.SobrenomeFuncionario);
                    comando.Parameters.AddWithValue("@DataDeNascimento", NovoNome.DatadeNascimento);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> Listar = new List<FuncionarioDomain>();

            using (SqlConnection conexao = new SqlConnection(stringconexao))
            {
                string queryComando = "SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario, DatadeNascimento FROM Funcionarios";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand com = new SqlCommand(queryComando, conexao))
                {
                    reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        FuncionarioDomain funcionarios = new FuncionarioDomain()
                        {
                            IdFuncionario = Convert.ToInt32(reader[0]),
                            NomeFuncionario = reader[1].ToString(),
                            SobrenomeFuncionario = reader[2].ToString(),
                            DatadeNascimento = Convert.ToDateTime(reader[3])
                        };

                        Listar.Add(funcionarios);
                    }

                    return Listar;
                }
            }
    }
    }
}

using SENAI_People_WebAPI.Domains;
using SENAI_People_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_People_WebAPI.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringconexao = "Data Source=DESKTOP-OPUNQ78; initial catalog=People; integrated security=true";
        public void Atualizar(FuncionarioDomain NomeFuncionario, FuncionarioDomain SobrenomeFuncionario)
        {
            throw new NotImplementedException();
        }

        public FuncionarioDomain BuscarPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirNovo(FuncionarioDomain NomeFuncionario, FuncionarioDomain SobrenomeFuncionario)
        {
            using (SqlConnection conexao = new SqlConnection (stringconexao))
            {
                string QueryInsert = "INSERT INTO Funcionarios (NomeFuncionario, SobrenomeFuncionario) VALUES ('" +NomeFuncionario+ "', '" +SobrenomeFuncionario +"'";

                conexao.Open();

                using (SqlCommand command = new SqlCommand (QueryInsert, conexao))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            List<FuncionarioDomain> Listar = new List<FuncionarioDomain>();

            using (SqlConnection conexao = new SqlConnection (stringconexao))
            {
                string queryComando = ("SELECT IdFuncionario, NomeFuncionario, SobrenomeFuncionario FROM People");

                conexao.Open();

                SqlDataReader Reader;

                using (SqlCommand com = new SqlCommand(queryComando, conexao))
                {
                    Reader = com.ExecuteReader();

                    while (Reader.Read())
                    {
                        FuncionarioDomain funcionarios = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(Reader[0]),
                            NomeFuncionario = Reader[1].ToString(),
                            SobrenomeRepositorio = Reader[2].ToString()
                        };

                        Listar.Add(funcionarios);
                    }
                    
                }
            }

            return Listar;
        }
    }
}

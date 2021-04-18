using Projeto_InLock_WebAPI.Domains;
using Projeto_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        //string de conexao com o banco de dados
        private string stringConexao = "Data Source = DESKTOP-SL5KKOH; initial catalog = InlockGames; integrated security = true";

        public void Cadastrar(JogosDomain NovoJogo)
        {
            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                string QueryCadastro = ("INSERT INTO Jogos (NomeJogo, Valor, Descricao, DataDeLancamento, IdEstudio) VALUES (@nome, @valor, @descricao, @data, @idestudio)");

                using (SqlCommand comando = new SqlCommand (QueryCadastro, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", NovoJogo.NomeJogo);
                    comando.Parameters.AddWithValue("@valor", NovoJogo.Valor);
                    comando.Parameters.AddWithValue("@descricao", NovoJogo.Descricao);
                    comando.Parameters.AddWithValue("@data", NovoJogo.DataDeLancamento);
                    comando.Parameters.AddWithValue("@idestudio", NovoJogo.IdEstudio);

                    conexao.Open();

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<JogosDomain> ListarJogos()
        {
            //lista para ser retornada com os dados armazenados
            List<JogosDomain> Listar = new List<JogosDomain>();

            using (SqlConnection conexao = new SqlConnection (stringConexao))
            {
                string QueryListar = (" SELECT NomeJogo, NomeEstudio FROM Jogos INNER JOIN Estudios ON Jogos.IdEstudio = Estudios.IdEstudio ");

                conexao.Open();

                //ler arquivos de formato sql
                SqlDataReader rdr;

                using (SqlCommand comando = new SqlCommand(QueryListar, conexao))
                {
                    rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogosDomain objetoJogos = new JogosDomain
                        {
                            NomeJogo = rdr["NomeJogo"].ToString(),
                            
                            //aqui é oq permite a junçao da tabela estudio com jogos :)
                            estudio = new EstudioDomain()
                            {
                                NomeEstudio = rdr["NomeEstudio"].ToString()
                            }
                        };

                        Listar.Add(objetoJogos);
                    }
                }
            }

            return Listar;
        }
    }
}

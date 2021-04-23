using Projeto_InLock_WebAPI.Domains;
using Projeto_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_InLock_WebAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string stringConexao = "Data Source = DESKTOP-SL5KKOH; initial catalog = InlockGames; integrated security = true"; 
        public List<EstudioDomain> BuscarJogo()
        {
            List<EstudioDomain> Lista = new List<EstudioDomain>();

            using (SqlConnection conexao = new SqlConnection(stringConexao))
            {
                string QueryJogo = ("SELECT NomeEstudio, NomeJogo FROM Estudios LEFT JOIN Jogos ON Estudios.IdEstudio = Jogos.IdEstudio");

                conexao.Open();

                SqlDataReader rdr;

                using (SqlCommand comando = new SqlCommand (QueryJogo, conexao))
                {
                    rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain Estudio = new EstudioDomain
                        {
                            NomeEstudio = rdr["NomeEstudio"].ToString(),

                            jogo = new JogosDomain
                            {
                                NomeJogo = rdr["NomeJogo"].ToString()
                            }
                        };

                        Lista.Add(Estudio);
                    }

                }
            }
            return Lista;
        }
    }
}

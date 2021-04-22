using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class Conexao
    {
        public SqlConnection conexao;
        public SqlCommand command;
        string strConexao = "Server=localhost;DataBase=ControleDeValor;user id=sa;password=12345";

        public Conexao()
        {

        }

        internal static void Open()
        {
            throw new NotImplementedException();
        }

        public void Conectar()
        {
            conexao = new SqlConnection(strConexao);
            conexao.Open();
            command = new SqlCommand();
            command.Connection = conexao;
        }

        public void FecharConexao()
        {
            conexao.Close();
            conexao = null;
            command = null;
        }
    }
}

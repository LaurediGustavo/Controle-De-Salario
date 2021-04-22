using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class DalHelperUsuario
    {
        public static Boolean RealizarLogin(string email, string senha)
        {
            try
            {
                Conexao c = new Conexao();
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter();

                c.Conectar();
                c.command.CommandText = "select *from Usuario where email=@email and senha=@senha";
                c.command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                c.command.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
                adapter.SelectCommand = c.command;
                adapter.Fill(ds);
                c.FecharConexao();

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Usuario.Id = (int)ds.Tables[0].Rows[0]["id"];
                    Usuario.Email = ds.Tables[0].Rows[0]["email"].ToString();
                    Usuario.MesAtualiza = ds.Tables[0].Rows[0]["mesAtualiza"].ToString();
                    Usuario.DiaAtualiza = ds.Tables[0].Rows[0]["diaAtualiza"].ToString();

                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void CadastroUsuario(string email, string senha)
        {
            Conexao c = new Conexao();

            c.Conectar();
            c.command.CommandText = "insert Usuario (email, senha) values (@email, @senha)";
            c.command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            c.command.Parameters.Add("@senha", SqlDbType.VarChar).Value = senha;
            c.command.ExecuteNonQuery();
            c.FecharConexao();

            RealizarLogin(email, senha);
        }

        public static Boolean DiaDeAlterarValor()
        {
            if (Usuario.DiaAtualiza == "" && Usuario.MesAtualiza == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CadastrarDia(string dia)
        {
            Conexao c = new Conexao();
            c.Conectar();
            c.command.CommandText = "update Usuario set diaAtualiza=@dia where id=@id";
            c.command.Parameters.Add("@dia", SqlDbType.VarChar).Value = dia;
            c.command.Parameters.Add("@id", SqlDbType.VarChar).Value = Usuario.Id;
            c.command.ExecuteNonQuery();
            c.FecharConexao();

            Usuario.DiaAtualiza = dia;
        }
    }
}

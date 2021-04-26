using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class DalHelperGastoValor
    {
        public static void InserirGasto(string desc, decimal valor, int id)
        {
            Conexao c = new Conexao();
            c.Conectar();
            c.command.CommandText = "insert Gasto (id_valor, valor, descricao, data) values (@id, @valor, @desc, @data)";
            c.command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valor;
            c.command.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
            c.command.Parameters.Add("@data", SqlDbType.DateTime).Value = DateTime.Now;
            c.command.ExecuteNonQuery();
            c.FecharConexao();
        }

        public static List<GastoValor> Gastos(int indice, string nome, decimal valor)
        {
            Conexao c = new Conexao();
            c.Conectar();

            if (indice != 0)
            {
                c.command.CommandText = "select *from Gasto where id_valor=@id";
                c.command.Parameters.Add("@id", SqlDbType.Int).Value = indice;
            }
            else
            {
                c.command.CommandText = "select *from Gasto where descricao like '" + nome + "' and valor =@valor";
                c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valor;
            }

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = c.command;
            adapter.Fill(ds);
            c.FecharConexao();

            List<GastoValor> gastoValors = new List<GastoValor>();

            if (ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GastoValor gasto = new GastoValor();
                    gasto.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    gasto.Id_valor = int.Parse(ds.Tables[0].Rows[i]["id_valor"].ToString());
                    gasto.Valor = decimal.Parse(ds.Tables[0].Rows[i]["valor"].ToString());
                    gasto.Descricao = ds.Tables[0].Rows[i]["descricao"].ToString();
                    gasto.Data =  DateTime.Parse(ds.Tables[0].Rows[i]["data"].ToString());

                    gastoValors.Add(gasto);
                }
            }

            return gastoValors;
        }

        public static DataSet GastosTotais()
        {
            Conexao c = new Conexao();
            c.Conectar();
            c.command.CommandText = "select valor from Gasto " +
                "where id_valor in (select id from Valor where id_usuario=@id)";
            c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = c.command;
            adapter.Fill(ds);
            c.FecharConexao();

            return ds;
        }

        internal static void DeletarGasto(List<GastoValor> gastos)
        {
            for (int i = 0; i < gastos.Count; i++)
            {
                Conexao c = new Conexao();
                c.Conectar();
                c.command.CommandText = "delete Gasto where id =@id";
                c.command.Parameters.Add("@id", SqlDbType.Int).Value = gastos[i].Id;
                c.command.ExecuteNonQuery();
                c.FecharConexao();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class DalHelperValor
    {
		public static List<Valor> valors = new List<Valor>();

		public static List<Valor> BuscarValor(string tipoBusca, string ano)
		{
			Conexao c = new Conexao();
			DataSet ds = new DataSet();
			SqlDataAdapter adapter = new SqlDataAdapter();

			c.Conectar();

			if (tipoBusca == "valor")
			{
				c.command.CommandText = "select *from Valor where id_usuario =@id and MONTH(data) =@mes and YEAR(data) =@ano";
				c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
				c.command.Parameters.Add("@mes", SqlDbType.Int).Value = int.Parse(Usuario.MesAtualiza);
				c.command.Parameters.Add("@ano", SqlDbType.Int).Value = (int)DateTime.Today.Year;
			}
			else if (tipoBusca == "ano")
			{
				c.command.CommandText = "select *from Valor where id_usuario =@id and YEAR(data) =@ano";
				c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
				c.command.Parameters.Add("@ano", SqlDbType.Int).Value = Convert.ToInt32(ano);
			}

			adapter.SelectCommand = c.command;
			adapter.Fill(ds);
			c.FecharConexao();

			if (ds.Tables[0].Rows.Count != 0)
			{
				valors.Clear();

				for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
				{
					Valor v = new Valor();

					v.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
					v.Id_usuario = Convert.ToInt32(ds.Tables[0].Rows[i]["id_usuario"].ToString());
					v.ValorTotal = Convert.ToDecimal(ds.Tables[0].Rows[i]["valorTotal"].ToString());
					v.ValorGuardado = Convert.ToDecimal(ds.Tables[0].Rows[i]["valorGuardado"].ToString());
					v.Data = Convert.ToDateTime(ds.Tables[0].Rows[i]["data"].ToString());

					valors.Add(v);
				}
			}

			return valors;
		}

		public static void AtualizarValor(string tipo, decimal valor)
		{
			Conexao c = new Conexao();

			c.Conectar();

			if (tipo == "ganho")
			{
				valors[0].ValorTotal = valors[0].ValorTotal + valor;
				c.command.CommandText = "update Valor set valorTotal=@valor where id=@id";
				c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valors[0].ValorTotal;
				c.command.Parameters.Add("@id", SqlDbType.Int).Value = valors[0].Id;
			}
			else if (tipo == "guardado")
			{
				valors[0].ValorGuardado = valors[0].ValorGuardado + valor;
				valors[0].ValorTotal = valors[0].ValorTotal - valor;
				c.command.CommandText = "update Valor set valorGuardado=@valor, valorTotal=@valorTotal where id=@id";
				c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valors[0].ValorGuardado;
				c.command.Parameters.Add("@valorTotal", SqlDbType.Decimal).Value = valors[0].ValorTotal;
				c.command.Parameters.Add("@id", SqlDbType.Int).Value = valors[0].Id;
			}
			else if (tipo == "resgatar")
			{
				valors[0].ValorGuardado = valors[0].ValorGuardado - valor;
				valors[0].ValorTotal = valors[0].ValorTotal + valor;
				c.command.CommandText = "update Valor set valorGuardado=@valor, valorTotal=@valorTotal where id=@id";
				c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valors[0].ValorGuardado;
				c.command.Parameters.Add("@valorTotal", SqlDbType.Decimal).Value = valors[0].ValorTotal;
				c.command.Parameters.Add("@id", SqlDbType.Int).Value = valors[0].Id;
			}
			else if (tipo == "atualiza")
			{
				c.command.CommandText = "insert Valor (id_usuario, valorTotal, valorGuardado, data) " +
					"values (@id, @valor, @valorGuar, @data); update Usuario set mesAtualiza=@mes where id=@id";
				c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
				c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valor;
				c.command.Parameters.Add("@valorGuar", SqlDbType.Decimal).Value = 0.00;
				c.command.Parameters.Add("@data", SqlDbType.DateTime).Value = DateTime.Now;
				c.command.Parameters.Add("@mes", SqlDbType.VarChar).Value = DateTime.Now.Month.ToString();

				Usuario.MesAtualiza = DateTime.Now.Month.ToString();
			}
			c.command.ExecuteNonQuery();
			c.FecharConexao();
		}

		public static DataTable RetornarData()
		{
			Conexao c = new Conexao();
			DataTable ds = new DataTable();
			SqlDataAdapter adapter = new SqlDataAdapter();

			c.Conectar();
			c.command.CommandText = "select distinct YEAR(v.data) as 'data' from Valor v " +
				"where id_usuario =@id order by YEAR(v.data) desc";
			c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
			adapter.SelectCommand = c.command;
			adapter.Fill(ds);
			c.FecharConexao();

			return ds;
		}

		public static DataSet TotalDosAnos()
		{
			Conexao c = new Conexao();
			DataSet ds = new DataSet();
			SqlDataAdapter adapter = new SqlDataAdapter();

			c.Conectar();
			c.command.CommandText = "select valorTotal, valorGuardado from Valor where id_usuario =@id";
			c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
			adapter.SelectCommand = c.command;
			adapter.Fill(ds);
			c.FecharConexao();

			return ds;
		}
	}
}

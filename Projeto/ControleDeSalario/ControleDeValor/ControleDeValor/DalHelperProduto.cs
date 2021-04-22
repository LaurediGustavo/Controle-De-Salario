using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class DalHelperProduto
    {
        internal static void CadastrarProduto(string nome, string valor, string valorMes, string valorAcu)
        {
            Conexao c = new Conexao();
            c.Conectar();
            c.command.CommandText = "insert into Produto (id_usuario, nome_produto, valor, valorMes, valorAcumulado) " +
                "values (@id, @nome, @valor, @valorMes, @valorAcu)";
            c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
            c.command.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
            c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valor;
            c.command.Parameters.Add("@valorMes", SqlDbType.Decimal).Value = valorMes;
            c.command.Parameters.Add("@valorAcu", SqlDbType.Decimal).Value = valorAcu;
            c.command.ExecuteNonQuery();
            c.FecharConexao();
        }

        static int soUm = 0;
        static int idProduto;

        internal static List<Produto> RetornarProdutos()
        {
            Conexao c = new Conexao();
            c.Conectar();

            if (soUm == 0)
            {
                c.command.CommandText = "select *from Produto where id_usuario =@id";
                c.command.Parameters.Add("@id", SqlDbType.Int).Value = Usuario.Id;
            }
            else
            {
                c.command.CommandText = "select *from Produto where id =@id";
                c.command.Parameters.Add("@id", SqlDbType.Int).Value = idProduto;
            }

            DataSet ds = new DataSet();
            SqlDataAdapter sql = new SqlDataAdapter();
            sql.SelectCommand = c.command;
            sql.Fill(ds);
            c.FecharConexao();

            List<Produto> produtos = new List<Produto>();

            if(ds.Tables[0].Rows.Count != 0)
            {
                for (int i = 0; i <ds.Tables[0].Rows.Count; i++)
                {
                    Produto produto = new Produto();

                    produto.Id = int.Parse(ds.Tables[0].Rows[i]["id"].ToString());
                    produto.Id_usuario = int.Parse(ds.Tables[0].Rows[i]["id_usuario"].ToString());
                    produto.Nome_produto = ds.Tables[0].Rows[i]["nome_produto"].ToString();
                    produto.Valor = decimal.Parse(ds.Tables[0].Rows[i]["valor"].ToString());
                    produto.ValorMes = decimal.Parse(ds.Tables[0].Rows[i]["valorMes"].ToString());
                    produto.ValorAcumulado = decimal.Parse(ds.Tables[0].Rows[i]["valorAcumulado"].ToString());

                    produtos.Add(produto);
                }
            }

            return produtos;
        }

        internal static void AtualizarGastoProduto(int id)
        {
            List<Produto> produtos = new List<Produto>();
            produtos = RetornarProdutos();

            for (int i = 0; i < produtos.Count; i++)
            {
                if (!(produtos[i].ValorAcumulado == produtos[i].Valor))
                {
                    if (produtos[i].ValorAcumulado + produtos[i].ValorMes > produtos[i].Valor)
                    {
                        decimal valor = produtos[i].Valor - produtos[i].ValorAcumulado;
                        produtos[i].ValorAcumulado += valor;

                        AtualizaValorAcumulado(produtos[i].ValorAcumulado, produtos[i].Id);
                        DalHelperGastoValor.InserirGasto(produtos[i].Nome_produto, valor, id);
                    }
                    else
                    {
                        produtos[i].ValorAcumulado += produtos[i].ValorMes;

                        AtualizaValorAcumulado(produtos[i].ValorAcumulado, produtos[i].Id);
                        DalHelperGastoValor.InserirGasto(produtos[i].Nome_produto, produtos[i].ValorMes, id);
                    }
                }
            }
        }

        internal static void ComprarProduto(int id)
        {
            Conexao c = new Conexao();
            c.Conectar();
            c.command.CommandText = "delete Produto where id=@id";
            c.command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            c.command.ExecuteNonQuery();
            c.FecharConexao();
        }

        internal static void CancelarProduto(int id)
        {
            soUm = 1;
            idProduto = id;

            List<Produto> produtos = new List<Produto>();
            produtos = RetornarProdutos();

            List<GastoValor> gastos = new List<GastoValor>();
            gastos = DalHelperGastoValor.Gastos(0, produtos[0].Nome_produto, produtos[0].ValorMes);

            DalHelperGastoValor.DeletarGasto(gastos);
            ComprarProduto(id);

            soUm = 0;
        }

        private static void AtualizaValorAcumulado(decimal valor, int id)
        {
            Conexao c = new Conexao();
            c.Conectar();
            c.command.CommandText = "update Produto set valorAcumulado=@valor where id=@id";
            c.command.Parameters.Add("@valor", SqlDbType.Decimal).Value = valor;
            c.command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            c.command.ExecuteNonQuery();
            c.FecharConexao();
        }
    }
}

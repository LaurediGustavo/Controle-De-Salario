using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class GastoValor
    {
        private int id;
        private int id_valor;
        private decimal valor;
        private string descricao;
        private DateTime data;

        public int Id { get => id; set => id = value; }
        public int Id_valor { get => id_valor; set => id_valor = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime Data { get => data; set => data = value; }

        public static decimal CalcularGasto(int indice)
        {
            List<GastoValor> valors = new List<GastoValor>();
            valors = DalHelperGastoValor.Gastos(indice, null, 0);

            decimal valor = 0;

            for (int i = 0; i < valors.Count; i++)
            {
                valor = valor + valors[i].valor;
            }

            return valor;
        }

        public static decimal CalcularGastosTotais()
        {
            DataSet ds = new DataSet();
            ds = DalHelperGastoValor.GastosTotais();

            decimal valor = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                valor = valor + decimal.Parse(ds.Tables[0].Rows[i]["valor"].ToString());
            }

            return valor;
        }
    }
}

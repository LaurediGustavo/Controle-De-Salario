using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class Produto
    {
		private int id;
		private int id_usuario;
		private string nome_produto;
		private Decimal valor;
		private Decimal valorMes;
		private Decimal valorAcumulado;

		public int Id { get => id; set => id = value; }
		public int Id_usuario { get => id_usuario; set => id_usuario = value; }
		public string Nome_produto { get => nome_produto; set => nome_produto = value; }
		public decimal Valor { get => valor; set => valor = value; }
		public decimal ValorMes { get => valorMes; set => valorMes = value; }
		public  decimal ValorAcumulado { get => valorAcumulado; set => valorAcumulado = value; }
	}
}

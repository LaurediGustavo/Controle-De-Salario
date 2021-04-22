using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class Valor
    {
		private int id;
		private int id_usuario;
		private decimal valorTotal;
		private decimal valorGuardado;
		private DateTime data;

		public int Id { get => id; set => id = value; }
		public int Id_usuario { get => id_usuario; set => id_usuario = value; }
		public decimal ValorTotal { get => valorTotal; set => valorTotal = value; }
		public decimal ValorGuardado { get => valorGuardado; set => valorGuardado = value; }
		public DateTime Data { get => data; set => data = value; }
	}
}

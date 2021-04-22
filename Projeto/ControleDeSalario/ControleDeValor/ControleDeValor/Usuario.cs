using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeValor
{
    class Usuario
    {
        private static int id;
	    private static string email;
	    private static string diaAtualiza;
	    private static string mesAtualiza;

        public static int Id { get => id; set => id = value; }
        public static string Email { get => email; set => email = value; }
        public static string DiaAtualiza { get => diaAtualiza; set => diaAtualiza = value; }
        public static string MesAtualiza { get => mesAtualiza; set => mesAtualiza = value; }
    }
}

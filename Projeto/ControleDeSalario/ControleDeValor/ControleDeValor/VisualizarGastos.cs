using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeValor
{
    public partial class VisualizarGastos : Form
    {
        public VisualizarGastos(int indice)
        {
            InitializeComponent();

            GerarDataGrid(indice);
        }

        private void GerarDataGrid(int indice)
        {
            dataGridView1.DataSource = DalHelperGastoValor.Gastos(indice, null, 0);

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;

            dataGridView1.Columns[2].HeaderText = "Valor";
            dataGridView1.Columns[3].HeaderText = "Descrição";
            dataGridView1.Columns[4].HeaderText = "Data";

            dataGridView1.Columns[2].Width = 195;
            dataGridView1.Columns[3].Width = 195;
            dataGridView1.Columns[4].Width = 195;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

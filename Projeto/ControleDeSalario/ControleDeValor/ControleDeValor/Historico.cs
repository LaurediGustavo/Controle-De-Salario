using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControleDeValor
{
    public partial class Historico : Form
    {
        List<Valor> valors = new List<Valor>();
        int indice = 0;

        public Historico()
        {
            InitializeComponent();
        }

        private void Historico_Load(object sender, EventArgs e)
        {
            RetornarAnos();
            valors = DalHelperValor.BuscarValor("ano", cbxAnos.SelectedValue.ToString());
            PreencharGrafico();
            TotalDosAnos();
        }

        private void TotalDosAnos()
        {
            DataSet ds = new DataSet();
            ds = DalHelperValor.TotalDosAnos();
            decimal guardado = 0;
            decimal restante = 0;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                guardado += Convert.ToDecimal(ds.Tables[0].Rows[i]["valorGuardado"].ToString());
                restante += (Convert.ToDecimal(ds.Tables[0].Rows[i]["valorTotal"].ToString()) - GastoValor.CalcularGastosTotais());
            }

            decimal total = guardado + restante;

            lblGuardado.Text = guardado.ToString();
            lblRestante.Text = restante.ToString();
            lblTotal.Text = total.ToString();
        }

        private void PreencharGrafico()
        {
            BloquearBotao();

            chart1.Series.Clear();
            chart1.Series.Add("Valores");
            chart1.Series["Valores"].ChartType = SeriesChartType.Pie;

            decimal restante = valors[indice].ValorTotal - GastoValor.CalcularGasto(valors[indice].Id);

            chart1.Series["Valores"].Points.AddXY("R$ " + valors[indice].ValorGuardado + " - " + "Guardado", valors[indice].ValorGuardado);
            chart1.Series["Valores"].Points.AddXY("R$ " + GastoValor.CalcularGasto(valors[indice].Id) + " - " + "Gasto", GastoValor.CalcularGasto(valors[indice].Id));
            chart1.Series["Valores"].Points.AddXY("R$ " + restante + " - " + "Restante", restante);

            lblValorTotal.Text = "Total - " + (valors[indice].ValorTotal + valors[indice].ValorGuardado);
            string data = Convert.ToString(valors[indice].Data);
            lblData.Text = data.Remove(10, 9);
        }

        private void BloquearBotao()
        {
            if (indice <= 0)
            {
                btnAnterior.Enabled = false;
            }
            else
            {
                btnAnterior.Enabled = true;
            }

            if (indice == valors.Count - 1)
            {
                btnProximo.Enabled = false;
            }
            else
            {
                btnProximo.Enabled = true;
            }
        }

        private void RetornarAnos()
        {
            cbxAnos.DataSource = DalHelperValor.RetornarData();
            cbxAnos.DisplayMember = "data";
            cbxAnos.ValueMember = "data";

            cbxAnos.SelectedValueChanged += CbxAnos_SelectedValueChanged;
        }

        private void CbxAnos_SelectedValueChanged(object sender, EventArgs e)
        {
            indice = 0;
            valors.Clear();
            valors = DalHelperValor.BuscarValor("ano", cbxAnos.SelectedValue.ToString());
            PreencharGrafico();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            indice--;
            PreencharGrafico();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            indice++;
            PreencharGrafico();
        }

        private void btnVisualizarGastos_Click(object sender, EventArgs e)
        {
            VisualizarGastos gastos = new VisualizarGastos(valors[indice].Id);
            gastos.ShowDialog();
        }
    }
}

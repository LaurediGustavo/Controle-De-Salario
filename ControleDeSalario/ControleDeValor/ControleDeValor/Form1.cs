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
    public partial class Form1 : Form  
    {
        List<Valor> valors = new List<Valor>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login l = new Login();
            l.ShowDialog();

            if (DalHelperUsuario.DiaDeAlterarValor())
            {
                DiaAlterar d = new DiaAlterar();
                d.ShowDialog();
            }

            if (Usuario.MesAtualiza == "")
            {
                Atualizar a = new Atualizar("atualiza", this, true);
                a.ShowDialog();
            }

            valors = DalHelperValor.BuscarValor("valor", null);

            if (int.Parse(DateTime.Now.Day.ToString()) >= int.Parse(Usuario.DiaAtualiza) && Usuario.MesAtualiza != DateTime.Now.Month.ToString())
            {
                Atualizar a = new Atualizar("atualiza", this, true);
                a.ShowDialog();

                DalHelperProduto.AtualizarGastoProduto(valors[0].Id);
            }

            GerarGrafico();
        }

        private void GerarGrafico()
        {
            valors = DalHelperValor.BuscarValor("valor", null);

            if (valors.Count != 0)
            {
                chGraficos.Series.Clear();
                chGraficos.Series.Add("Valores");
                chGraficos.Series["Valores"].ChartType = SeriesChartType.Pie;

                decimal restante = valors[0].ValorTotal - GastoValor.CalcularGasto(valors[0].Id);

                chGraficos.Series["Valores"].Points.AddXY("R$ " + valors[0].ValorGuardado + " - " + "Guardado", valors[0].ValorGuardado);
                chGraficos.Series["Valores"].Points.AddXY("R$ " + GastoValor.CalcularGasto(valors[0].Id) + " - " + "Gasto", GastoValor.CalcularGasto(valors[0].Id));
                chGraficos.Series["Valores"].Points.AddXY("R$ " + restante + " - " + "Restante", restante);

                lblValorTotal.Text = "Total - " + (valors[0].ValorTotal + valors[0].ValorGuardado);
                string data = Convert.ToString(valors[0].Data);
                lblData.Text = data.Remove(10, 9);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Atualizar a = new Atualizar("guardar", this, false);
            a.ShowDialog();
        }

        private void btnGanho_Click(object sender, EventArgs e)
        {
            Atualizar a = new Atualizar("ganho", this, false);
            a.ShowDialog();
        }

        private void btnGasto_Click(object sender, EventArgs e)
        {
            Gasto a = new Gasto(this, valors[0].Id);
            a.ShowDialog();
        }

        public void AtualizaForm()
        {
            GerarGrafico();
        }

        private void btnResgatar_Click(object sender, EventArgs e)
        {
            Atualizar a = new Atualizar("resgatar", this, false);
            a.ShowDialog();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            Historico h = new Historico();
            h.ShowDialog();
        }

        bool boo = false;
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (!boo)
            {
                for (int i = -206; i < 0; i++)
                {
                    panel1.Location = new Point(i, 30);
                }

                boo = true;
            }
            else
            {
                for (int i = 0; i > -206; i--)
                {
                    panel1.Location = new Point(i, 30);
                }

                boo = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VisualizarGastos v = new VisualizarGastos(valors[0].Id);
            v.ShowDialog();
        }

        private void btnEconomizar_Click(object sender, EventArgs e)
        {
            Economizar eco = new Economizar(this, valors[0].Id);
            eco.ShowDialog();
        }
    }
}

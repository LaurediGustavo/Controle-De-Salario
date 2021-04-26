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
    public partial class Economizar : Form
    {
        Form1 form;
        int id;

        public Economizar(Form1 form, int id)
        {
            InitializeComponent();

            this.form = form;
            this.id = id;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            pnlAdc.Visible = true;
            dataGridView1.Visible = false;
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            pnlAdc.Visible = false;
            dataGridView1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ValidarCampos();
        }

        private void Economizar_Load(object sender, EventArgs e)
        {
            PovoarDataGrid();

            pnlAdc.Visible = false;

            FormClosing += Economizar_FormClosing;
            dataGridView1.CellClick += DataGridView1_CellClick;
            AplicarEventos(txtValorProduto);
            AplicarEventos(txtValorPMes);
        }

        private void Economizar_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.AtualizaForm();
        }

        private void PovoarDataGrid()
        {
            dataGridView1.DataSource = DalHelperProduto.RetornarProdutos();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;

            dataGridView1.Columns[2].HeaderText = "Nome";
            dataGridView1.Columns[3].HeaderText = "Valor";
            dataGridView1.Columns[4].HeaderText = "Valor por mês";
            dataGridView1.Columns[5].HeaderText = "Valor acumulado";

            dataGridView1.Columns[2].Width = 190;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].Width = 170;
            dataGridView1.Columns[5].Width = 170;

            dataGridView1.AutoSize = false;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.Equals(dataGridView1.Rows[e.RowIndex].Cells[5].Value))
                {
                    var result = MessageBox.Show("Deseja realizar essa compra?", "Compra", 
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DalHelperProduto.ComprarProduto(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));

                        MessageBox.Show("Compra realizada com sucesso!", "Compra",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        var result2 = MessageBox.Show("Deseja cancelar essa compra?", "Cancelar",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result2 == DialogResult.Yes)
                        {
                            DalHelperProduto.CancelarProduto(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));

                            MessageBox.Show("Compra cancelada com sucesso!", "Compra",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    var result = MessageBox.Show("Você não tem o dinheiro necessário para realizar essa compra. Deseja cancelar ela?", 
                        "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DalHelperProduto.CancelarProduto(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));

                        MessageBox.Show("Produto cancelado com sucesso!", "Compra",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                PovoarDataGrid();
            }

        }

        private void ValidarCampos()
        {
            if (txtProduto.Text == "" || txtValorProduto.Text == "" || txtValorPMes.Text == "")
            {
                MessageBox.Show("Preencha os campos corretamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (decimal.Parse(txtValorProduto.Text) <= 0){
                MessageBox.Show("O valor do produto está incorreto!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (decimal.Parse(txtValorPMes.Text) >= decimal.Parse(txtValorProduto.Text) || decimal.Parse(txtValorPMes.Text) <= 0)
            {
                MessageBox.Show("O valor por mês não pode ser maior ou igual ao do produto!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var result = MessageBox.Show("Os valores " + RetornarMascara(txtValorProduto) + " ," + 
                    RetornarMascara(txtValorPMes) + " estão corretos?", "", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var result2 = MessageBox.Show("Você deseja economizar a partir desse mês?", "", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                    {
                        DalHelperProduto.CadastrarProduto(txtProduto.Text, txtValorProduto.Text, txtValorPMes.Text, txtValorPMes.Text);

                        DalHelperGastoValor.InserirGasto(txtProduto.Text, TirarMascara(txtValorPMes), id);
                    }
                    else
                    {
                        DalHelperProduto.CadastrarProduto(txtProduto.Text, txtValorProduto.Text, txtValorPMes.Text, "0");
                    }

                    txtProduto.Text = "";
                    txtValorProduto.Text = "";
                    txtValorPMes.Text = "";
                    pnlAdc.Visible = false;
                    dataGridView1.Visible = true;
                    PovoarDataGrid();
                }
            }
        }

        private void AplicarEventos(TextBox txt)
        {
            txt.KeyPress += ApenasValorNumerico;
        }

        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(','));
                }
                else
                    e.Handled = true;
            }
        }

        private String RetornarMascara(TextBox text)
        {
            if (!text.Equals(""))
            {
                return double.Parse(text.Text).ToString("C2");
            }
            else
            {
                return null;
            }
        }

        private Decimal TirarMascara(TextBox text)
        {
            string valor = RetornarMascara(text);

            return Convert.ToDecimal(valor.Replace("R$", "").Trim());
        }
    }
}

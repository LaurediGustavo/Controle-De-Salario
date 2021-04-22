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
    public partial class Gasto : Form
    {
        Form1 form;
        int id;

        public Gasto(Form1 form, int id)
        {
            InitializeComponent();

            this.form = form;
            this.id = id;
            FormClosing += Gasto_FormClosing;
            AplicarEventos(txtValor);
        }

        private void Gasto_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.AtualizaForm();
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

        private String RetornarMascara()
        {
            if (!txtValor.Text.Equals(""))
            {
                return double.Parse(txtValor.Text).ToString("C2");
            }
            else
            {
                return null;
            }
        }

        private Decimal TirarMascara()
        {
            string valor = RetornarMascara();

            return Convert.ToDecimal(valor.Replace("R$", "").Trim());
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "" || txtDescricao.Text == "")
            {
                MessageBox.Show("Preencha os campos!", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var result = MessageBox.Show("O valor " + RetornarMascara() + " está correto?", "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DalHelperGastoValor.InserirGasto(txtDescricao.Text, TirarMascara(), id);
                    Close();
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

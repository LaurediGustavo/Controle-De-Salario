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
    public partial class Atualizar : Form
    {
        string valor;
        Form1 form;

        public Atualizar(string valor, Form1 form, bool btn)
        {
            InitializeComponent();

            AplicarEventos(txtValor);

            this.valor = valor;
            this.form = form;
            this.FormClosing += Atualizar_FormClosing;

            if (btn)
            {
                btnFechar.Enabled = false;
                label2.Text = "Informe o valor do seu salário:";
            }
        }

        private void Atualizar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.AtualizaForm();
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!txtValor.Text.Equals(""))
            {
                var result = MessageBox.Show("O valor " + RetornarMascara() + " está correto?", "", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    switch (valor)
                    {
                        case "ganho":
                            DalHelperValor.AtualizarValor("ganho", TirarMascara());

                            break;

                        case "guardar":
                            decimal restante = (DalHelperValor.valors[0].ValorTotal - DalHelperValor.valors[0].ValorGuardado) - GastoValor.CalcularGasto(0);
                            
                            if (TirarMascara() > restante)
                            {
                                MessageBox.Show("Quantidade acima do valor restante!", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                DalHelperValor.AtualizarValor("guardado", TirarMascara());
                            }

                            break;

                        case "resgatar":
                            if (TirarMascara() > DalHelperValor.valors[0].ValorGuardado)
                            {
                                MessageBox.Show("Quantidade acima do valor guardado!", "",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                DalHelperValor.AtualizarValor("resgatar", TirarMascara());
                            }

                            break;

                        case "atualiza":
                            DalHelperValor.AtualizarValor("atualiza", TirarMascara());

                            break;
                    }

                    Close();
                }
            }
            else
            {
                MessageBox.Show("Informe um valor!", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

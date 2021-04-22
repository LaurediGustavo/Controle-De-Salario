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
    public partial class Cadastro : Form
    {
        Login form;
        public Cadastro(Login form)
        {
            InitializeComponent();

            this.form = form;
            FormClosing += Cadastro_FormClosing;
        }

        private void Cadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form.FecharForm();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Informe os dados corretamente!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtSenha.Text.Length < 8)
            {
                MessageBox.Show("Sua senha tem que ter 8 digitos no mínimo!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cadastro realizado com sucesso!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DalHelperUsuario.CadastroUsuario(txtEmail.Text, txtSenha.Text);
                Close();
            }
        }

        private void btnEntrar_MouseHover(object sender, EventArgs e)
        {
            btnEntrar.FlatAppearance.BorderColor = Color.Yellow;
            btnEntrar.ForeColor = Color.Yellow;
        }

        private void btnEntrar_MouseLeave(object sender, EventArgs e)
        {
            btnEntrar.FlatAppearance.BorderColor = Color.White;
            btnEntrar.ForeColor = Color.White;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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

        private void btnSair_MouseHover(object sender, EventArgs e)
        {
            btnSair.FlatAppearance.BorderColor = Color.Red;
            btnSair.ForeColor = Color.Red;
        }

        private void btnSair_MouseLeave(object sender, EventArgs e)
        {
            btnSair.FlatAppearance.BorderColor = Color.White;
            btnSair.ForeColor = Color.White;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtSenha.Text != "")
            {
                if (DalHelperUsuario.RealizarLogin(txtEmail.Text, txtSenha.Text))
                {
                    Close();
                }
                else
                {
                    lblErroLogin.Text = "Login inválido";
                }
            }
            else
            {
                lblErroLogin.Text = "Login inválido";
            }
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            Cadastro cadastro = new Cadastro(this);
            cadastro.ShowDialog();
        }

        private void btnCadastro_MouseHover(object sender, EventArgs e)
        {
            btnCadastro.FlatAppearance.BorderColor = Color.Blue;
            btnCadastro.ForeColor = Color.Blue;
        }

        private void btnCadastro_MouseLeave(object sender, EventArgs e)
        {
            btnCadastro.FlatAppearance.BorderColor = Color.White;
            btnCadastro.ForeColor = Color.White;
        }

        public void FecharForm()
        {
            Close();
        }
    }
}

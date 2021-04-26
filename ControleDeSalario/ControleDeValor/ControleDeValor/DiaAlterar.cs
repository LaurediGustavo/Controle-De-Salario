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
    public partial class DiaAlterar : Form
    {
        public DiaAlterar()
        {
            InitializeComponent();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (txtValor.Text == "")
            {
                MessageBox.Show("Informe um dia!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (Convert.ToInt32(txtValor.Text) > 31 || Convert.ToInt32(txtValor.Text) < 1)
            {
                MessageBox.Show("Informe um dia válido!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string data;

                if (txtValor.Text.Length == 1)
                {
                    data = "0" + txtValor.Text;
                }
                else
                {
                    data = txtValor.Text;
                }

                var result = MessageBox.Show("A dia " + data + " está correto?", "", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DalHelperUsuario.CadastrarDia(data);

                    Close();
                }
            }
        }
    }
}

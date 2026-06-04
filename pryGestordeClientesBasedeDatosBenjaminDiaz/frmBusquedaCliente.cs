using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryGestordeClientesBasedeDatosBenjaminDiaz
{
    public partial class frmBusquedaCliente : Form
    {
        public frmBusquedaCliente()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Int32 IDCliente = Convert.ToInt32(txtCodigo.Text);
            clsCliente x = new clsCliente();
            x.Buscar(IDCliente);

            if (x.IdCli != 0)
            {
                lblNombre.Text = x.Nombre;
                lblDeuda.Text = x.Deuda.ToString();
                lblLimite.Text = x.Limite.ToString();
            }
            else
            {
                lblNombre.Text = "";
                lblDeuda.Text = "";
                lblLimite.Text = "";
                MessageBox.Show("Cliente no existente");

            }
        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void gboDatosCliente_Enter(object sender, EventArgs e)
        {

        }
    }
}

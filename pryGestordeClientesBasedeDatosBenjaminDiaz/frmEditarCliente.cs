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
    public partial class frmEditarCliente : Form
    {
        public frmEditarCliente()
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
                txtLimite.Text = "";
                MessageBox.Show("Dato no existente");

            }
            txtLimite.ReadOnly = true;
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = true;
        }

        private void frmEditarCliente_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                btnBuscar.Enabled = true;

            }
            else
            {
                btnBuscar.Enabled = false;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            txtLimite.ReadOnly = false;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            clsCliente x = new clsCliente();
            Int32 id = Convert.ToInt32(txtCodigo.Text);

            x.Limite = Convert.ToDecimal(txtLimite.Text);
            x.Modificar(id);
            MessageBox.Show("Datos modificados");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            clsCliente x = new clsCliente();
            Int32 id = Convert.ToInt32(txtCodigo.Text);

            x.Eliminar(id);
            MessageBox.Show("Cliente eliminado");
        }
    }
}

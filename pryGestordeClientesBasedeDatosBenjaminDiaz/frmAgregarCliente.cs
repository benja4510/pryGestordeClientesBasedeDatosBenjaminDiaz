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
    public partial class frmAgregarCliente : Form
    {
        public frmAgregarCliente()
        {
            InitializeComponent();
        }

        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {
              clsAutomovil auto = new clsAutomovil();
            auto.Listar(cmbAutomovil);
        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            clsCliente x = new clsCliente();
            x.Nombre = txtNombre.Text;
            x.Limite = Convert.ToDecimal(txtLimite.Text);
            x.idAutomovil = Convert.ToInt32(cmbAutomovil.SelectedValue);
            x.Agregar();

            MessageBox.Show("Datos Grabados");
            txtNombre.Text = "";
            txtLimite.Text = "";
            cmbAutomovil.SelectedIndex = 0;

        }

        private void btnCargarSQL_Click(object sender, EventArgs e)
        {
            clsCliente x = new clsCliente();
            x.Nombre = txtNombre.Text;
            x.Limite = Convert.ToDecimal(txtLimite.Text);
            x.idAutomovil = Convert.ToInt32(cmbAutomovil.SelectedValue);
            x.AgregarNuevoRegistro();

            MessageBox.Show("Datos Grabados");
            txtNombre.Text = "";
            txtLimite.Text = "";
            cmbAutomovil.SelectedIndex = 0;
        }
    }
}

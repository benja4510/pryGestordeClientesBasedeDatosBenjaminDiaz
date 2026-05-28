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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmListadoClientes = new frmListadoClientes();
            frmListadoClientes.ShowDialog();
        }

        private void listadoDeClientesDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmClientesDeudores = new frmClientesDeudores();
            frmClientesDeudores.ShowDialog();
        }

        private void buscarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmBusquedaCliente = new frmBusquedaCliente();
            frmBusquedaCliente.ShowDialog();
        }
    }
}

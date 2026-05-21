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
    public partial class frmClientesDeudores : Form
    {
        public frmClientesDeudores()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsCliente x = new clsCliente();
            x.ReporteCliente(dgvGrilla);
            lblCantidad.Text = x.CantidadDeudores.ToString("0.00");
            lblTotal.Text = x.TotalDeuda.ToString();
            lblPromedioDeuda.Text = x.PromedioDeuda.ToString("0.00");
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            clsCliente x = new clsCliente();
            x.ReporteCliente(dgvGrilla);
            MessageBox.Show("Reporte generado correctamente", "Reporte de Clientes Deudores", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

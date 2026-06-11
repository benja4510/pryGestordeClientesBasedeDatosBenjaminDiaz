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
            x.ListarDeudores(dgvGrilla);
            lblCantidad.Text = x.CantidadDeudores.ToString("0.00");
            lblTotal.Text = x.TotalDeuda.ToString();
            lblPromedioDeuda.Text = x.PromedioDeuda.ToString("0.00");
        }

        private void btnReportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog objArchivo = new SaveFileDialog();
            objArchivo.Title = "Seleccione Carpeta y escriba nombre de archivo";
            objArchivo.RestoreDirectory = true;
            objArchivo.Filter = "Archivo separado por coma (*.csv) |*.csv|Archivo de texto (*.txt)|*.txt";





            objArchivo.ShowDialog();

            clsCliente x = new clsCliente();
            x.ReporteCliente(dgvGrilla);
            MessageBox.Show("Reporte generado correctamente", "Reporte de Clientes Deudores", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            prtVentana.ShowDialog();
            prtDocumento.PrinterSettings = prtVentana.PrinterSettings;
            prtDocumento.Print();
            MessageBox.Show("Reporte Impreso Correctamente");
        }

        private void prtDocumento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            clsCliente x = new clsCliente();
            x.Imprimir(e);

            //  Ejemplo de escritura directa
            //  Font TipoLetra = new Font("Arial", 12);
            //  e.Graphics.DrawString("Hola", TipoLetra, Brushes.Blue, 200, 200);

        }
    }
}


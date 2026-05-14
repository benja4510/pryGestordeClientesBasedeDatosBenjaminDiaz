using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;    

namespace pryGestordeClientesBasedeDatosBenjaminDiaz
{
    internal class clsCliente
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private String CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Alumno\\source\\repos\\pryGestordeClientesBasedeDatosBenjaminDiaz\\pryGestordeClientesBasedeDatosBenjaminDiaz\\bin\\Debug\\Clientes.mdb";
        private String Tabla = "Clientes";

        public void Listar(DataGridView Grilla) 
        {
            //try-catch para manejar posibles errores al conectar con la base de datos o al ejecutar la consulta
            try
            {

                //Listar los clientes en el DataGridView
                conexion.ConnectionString = CadenaConexion;

                //Abrir la conexión
                conexion.Open();

                //Configurar el comando para obtener los datos de la tabla Clientes
                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                //Configurar el adaptador para llenar el DataSet con los datos de la tabla Clientes
                adaptador = new OleDbDataAdapter(comando);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);

                //Asignar el DataSet al DataGridView para mostrar los datos
                Grilla.DataSource = ds.Tables[0];

                //Cerrar la conexión
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());

            }
        }

    }
}

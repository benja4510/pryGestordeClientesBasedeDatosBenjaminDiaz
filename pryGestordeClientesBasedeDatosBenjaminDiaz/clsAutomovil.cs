using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;    

namespace pryGestordeClientesBasedeDatosBenjaminDiaz
{
    internal class clsAutomovil
    {

        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private String CadenaConexion = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Clientes.mdb";
        private String Tabla = "automovil";


        public void Listar(DataGridView Grilla)
        {
            //try-catch para manejar posibles errores al conectar con la base de datos o al ejecutar la consulta
            try
            {
                //Listar los clientes en el DataGridView
                conexion.ConnectionString = CadenaConexion;

                //Abrir la conexión
                conexion.Open();

                //Configurar el comando usando una consulta SQL de texto
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text; // <-- CAMBIADO
                comando.CommandText = "SELECT * FROM [Cliente]";
                //Configurar el adaptador para llenar el DataSet con los datos de la consulta
                adaptador = new OleDbDataAdapter(comando);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);

                //Asignar el DataSet al DataGridView para mostrar los datos
                Grilla.DataSource = ds.Tables[Tabla];

                //Cerrar la conexión
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }

        public void Listar(ComboBox Combo)
        {
            //try-catch para manejar posibles errores al conectar con la base de datos o al ejecutar la consulta
            try
            {
                //Listar los clientes en el DataGridView
                conexion.ConnectionString = CadenaConexion;

                //Abrir la conexión
                conexion.Open();

                //Configurar el comando usando una consulta SQL de texto
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text; // <-- CAMBIADO
                comando.CommandText = "SELECT * FROM [Cliente]";
                //Configurar el adaptador para llenar el DataSet con los datos de la consulta
                adaptador = new OleDbDataAdapter(comando);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);

                //Asignar el DataSet al DataGridView para mostrar los datos
                Combo.DataSource = ds.Tables[Tabla];
                Combo.DisplayMember = "Nombre";
                Combo.ValueMember = "idAutomovil";

                //Cerrar la conexión
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
}   }

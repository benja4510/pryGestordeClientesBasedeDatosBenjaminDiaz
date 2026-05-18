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

        private String CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Alumno\\Downloads\\Clientes.mdb";
        private String Tabla = "Clientes";

        //Atributos para almacenar la deuda total y la cantidad de deudores
        private decimal deuda;
        private Int32 cantidad;

        //Propiedades para acceder a los atributos de deuda y cantidad
        public decimal TotalDeuda
        {
            get { return deuda; }
           
        }
                                
        public Int32 CantidadDeudores
        {
            get { return cantidad; }
            

        }
        public Decimal PromedioDeuda
        {
            get { return deuda / cantidad; }

        }

        //Método para listar todos los clientes en un DataGridView
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
        public void ListarDeudores(DataGridView Grilla)
        {

            try
            {

                conexion.ConnectionString = CadenaConexion;
                conexion.Open();


                comando.Connection = conexion;
                comando.CommandType = CommandType.TableDirect;
                comando.CommandText = Tabla;

                OleDbDataReader DR = comando.ExecuteReader();
                
                cantidad = 0;
                deuda = 0;
                Grilla.Rows.Clear();

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {

                        if (DR.GetDecimal(2) > 0)
                        {
                            Grilla.Rows.Add(DR.GetInt32(0), DR.GetString(1), DR.GetDecimal(2));
                            cantidad++;
                            deuda += DR.GetDecimal(2);
                        }
                    }

                }

                conexion.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());


            }
        }

    }
}

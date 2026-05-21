using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Net.Http.Headers;

namespace pryGestordeClientesBasedeDatosBenjaminDiaz
{
    internal class clsCliente
    {
        private OleDbConnection conexion = new OleDbConnection();
        private OleDbCommand comando = new OleDbCommand();
        private OleDbDataAdapter adaptador = new OleDbDataAdapter();

        private String CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Alumno\\Downloads\\Clientes.mdb";
        private String Tabla = "Cliente";

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
            get
            {
                // Si la cantidad es mayor a cero, hace el cálculo. Si es cero, devuelve 0.
                if (cantidad > 0)
                {
                    return deuda / cantidad;
                }
                else
                {
                    return 0;
                }
            }
        }

        //Método para listar todos los clientes en un DataGridView
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

                //Configurar el comando usando una consulta SQL de texto
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text; // <-- CAMBIADO
                comando.CommandText = "SELECT * FROM [Cliente]";
                //Configurar el adaptador para llenar el DataSet con los datos de la consulta
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
                comando.CommandText = "SELECT * FROM [Cliente]";

                OleDbDataReader DR = comando.ExecuteReader();
                StreamWriter AD = new StreamWriter("ReporteClientes.csv", false, Encoding.UTF8);

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
                            deuda = deuda + DR.GetDecimal(2);
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




        public void ReporteCliente(DataGridView Grilla)
        {
            try
            {
                conexion.ConnectionString = CadenaConexion;
                conexion.Open();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM [Cliente]";

                OleDbDataReader DR = comando.ExecuteReader();
                StreamWriter AD = new StreamWriter("ReporteClientes.csv", false,Encoding.UTF8);

                AD.WriteLine("Listado de clientes");
                AD.WriteLine("Codigo;Nombre;Deuda"); // Usamos punto y coma para mantener el estándar de Excel

                cantidad = 0;
                deuda = 0;
                Grilla.Rows.Clear();

                if (DR.HasRows)
                {
                    while (DR.Read())
                    {
                        // 1. Escribimos los datos del cliente en una SOLA línea usando Write (no WriteLine a cada rato)
                        AD.Write(DR.GetInt32(0));
                        AD.Write(";");
                        AD.Write(DR.GetString(1));
                        AD.Write(";");
                        AD.WriteLine(DR.GetDecimal(2)); // Al final de la línea sí va WriteLine

                        // También lo agregamos a la grilla visual por si lo necesitas
                        Grilla.Rows.Add(DR.GetInt32(0), DR.GetString(1), DR.GetDecimal(2));

                        cantidad++;
                        deuda += DR.GetDecimal(2);
                    }

                    // 2. Los totales van AFUERA del bucle while. Si los dejas adentro, se escriben por cada cliente.
                    AD.WriteLine(); // Espacio en blanco
                    AD.WriteLine("Cantidad de Clientes:;;" + cantidad);

                    // Protegemos la división por cero aquí también
                    decimal promedio = cantidad > 0 ? (deuda / cantidad) : 0;
                    AD.WriteLine("Promedio de Deuda:;;" + promedio);
                }

                // --- AQUÍ VA EL CLOSE DEL ARCHIVO ---
                AD.Close();

                DR.Close();
                conexion.Close();

                MessageBox.Show("Reporte generado con éxito.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }   

    }
}


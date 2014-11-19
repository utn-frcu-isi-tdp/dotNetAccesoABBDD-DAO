using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Aplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conexion = new SqlConnection(@"Data Source=(localdb)\v11.0;
                                                              Initial Catalog = PruebaDB;
                                                              Integrated Security = true;"))
            {
                SqlCommand comando = conexion.CreateCommand();

                comando.CommandText = "select * from Persona";

                DataTable tabla = new DataTable();

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        Console.WriteLine("Id:{0}", Convert.ToString(fila["IdPersona"]));
                        Console.WriteLine("Nombre:{0}", Convert.ToString(fila["Nombre"]));
                        Console.WriteLine("Apellido:{0}", Convert.ToString(fila["Apellido"]));
                    }

                }

                Console.ReadKey();
            }
        }
    }
}

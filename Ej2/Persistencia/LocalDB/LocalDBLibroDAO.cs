using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ej2.DTO;

namespace Ej2.Persistencia.LocalDB
{
    public class LocalDBLibroDAO : ILibroDAO
    {
        private SqlConnection iConexion;

        public LocalDBLibroDAO(SqlConnection pConexion)
        {
            this.iConexion = pConexion;
        }

        public void Insertar(LibroDTO pLibroDTO)
        {
            try
            {
                SqlCommand comando = this.iConexion.CreateCommand();

                comando.CommandText = @"insert into Libro(  Id,
                                                            Autor,
                                                            Titulo,
                                                            ISBN)
                                        values(@Id,
                                               @Autor,
                                               @Titulo,
                                               @ISBN)";

                comando.Parameters.AddWithValue("@Id", pLibroDTO.Id);
                comando.Parameters.AddWithValue("@Autor", pLibroDTO.Autor);
                comando.Parameters.AddWithValue("@Titulo", pLibroDTO.Titulo);
                comando.Parameters.AddWithValue("@ISBN", pLibroDTO.ISBN);

                comando.ExecuteNonQuery();
            }
            catch(SqlException pSqlException)
            {
                throw new DAOException("Error en la inserción de datos de libro",
                                       pSqlException);
            }
        }

        public IList<LibroDTO> Obtener()
        {
            List<LibroDTO> mLibros = new List<LibroDTO>();

            try
            {
                SqlCommand comando = this.iConexion.CreateCommand();

                comando.CommandText = "select * from Libro";

                DataTable tabla = new DataTable();

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);

                    foreach (DataRow fila in tabla.Rows)
                    {
                        mLibros.Add(new LibroDTO
                        {
                            Id = Convert.ToInt32(fila["Id"]),
                            Autor = Convert.ToString(fila["Autor"]),
                            ISBN = Convert.ToString(fila["ISBN"]),
                            Titulo = Convert.ToString(fila["Titulo"])
                        });

                    }

                }

                return mLibros;
            }
            catch (SqlException pSqlException)
            {
                throw new DAOException("Error en la obtención de datos de libro",
                                       pSqlException);
            }
        }

        public void Actualizar(LibroDTO pLibroDTO)
        {
            throw new NotImplementedException();
        }

        public void Borrar(LibroDTO pLibroDTO)
        {
            throw new NotImplementedException();
        }
    }
}

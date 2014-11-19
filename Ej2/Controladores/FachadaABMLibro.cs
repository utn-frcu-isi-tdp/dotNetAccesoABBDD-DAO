using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ej2.DTO;
using Ej2.Persistencia;

namespace Ej2.Controladores
{
    /// <summary>
    /// Clase controlador de fachada
    /// </summary>
    public class FachadaABMLibro
    {

        /// <summary>
        /// Obtención de todos los libros
        /// </summary>
        /// <returns>Lista de <code>LibroDTO</code></returns>
        public IList<LibroDTO> ListarLibros()
        {
            DAOFactory mFactory = null;
               
            try
            {
                mFactory = DAOFactory.Instancia;

                mFactory.IniciarConexion();
             
                // se devuelven los libros
                return mFactory.LibroDAO.Obtener();

            }
            finally
            {
                // Si hay un error o no se cierra la conexion
                mFactory.FinalizarConexion();
            }          
          
        }

        /// <summary>
        /// Alta de libros
        /// </summary>
        /// <param name="pLibroDTO">Clase DTO con los datos de libro.</param>
        public void CrearLibro(LibroDTO pLibroDTO)
        {
            DAOFactory mFactory = null;

            try
            {
                mFactory = DAOFactory.Instancia;

                // Se inicia la conexión
                mFactory.IniciarConexion();

                // Se inicia la transacción
                mFactory.IniciarTransaccion();

                // Se inserta el libro
                mFactory.LibroDAO.Insertar(pLibroDTO);

                // SI todo va bien, se realiza un commit
                mFactory.Commit();
            }
            catch(Exception e)
            {
                // error, se realiza un rollback
                mFactory.RollBack();

                // se relanza la excepción porque en este punto no se puede tratar
                throw e;
            }
            finally
            {
                // Si hubo un error o no se cierra la transacción.
                mFactory.FinalizarConexion();
            }
            


        }

        public void ModificarLibro(LibroDTO pLibroDTO)
        {
            throw new Exception("No implementado!!!");
        }

        public void BorrarLibro(LibroDTO pLibroDTO)
        {
            throw new Exception("No implementado!!!");
        }
    }
}

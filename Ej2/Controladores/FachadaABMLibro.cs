using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ej2.DTO;
using Ej2.Persistencia;

namespace Ej2.Controladores
{
    class FachadaABMLibro
    {

        public IList<LibroDTO> ListarLibros()
        {
            DAOFactory mFactory = null;
               
            try
            {
                mFactory = DAOFactory.Instancia;

                mFactory.IniciarConexion();
             
                return mFactory.LibroDAO.Obtener();

            }
            finally
            {
                mFactory.FinalizarConexion();
            }          
          
        }

        public void CrearLibro(LibroDTO pLibroDTO)
        {
            DAOFactory mFactory = null;

            try
            {
                mFactory = DAOFactory.Instancia;

                mFactory.IniciarConexion();

                mFactory.IniciarTransaccion();

                mFactory.LibroDAO.Insertar(pLibroDTO);

                mFactory.Commit();
            }
            catch(Exception e)
            {
                mFactory.RollBack();

                throw e;
            }
            finally
            {
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

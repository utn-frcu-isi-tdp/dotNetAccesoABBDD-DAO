using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ej2.Persistencia.LocalDB;

namespace Ej2.Persistencia
{
    public abstract class DAOFactory
    {
       public abstract ILibroDAO LibroDAO {get;}

       public abstract void IniciarConexion();
       public abstract void FinalizarConexion();
       public abstract void IniciarTransaccion();
       public abstract void Commit();
       public abstract void RollBack();

       public static DAOFactory Instancia
       {
           get
           {
               return new LocalDBDAOFactory();
           }
       }
    

    }
}

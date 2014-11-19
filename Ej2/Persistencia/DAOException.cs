using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2.Persistencia
{
    
    /// <summary>
    /// Excepción que representa un error en la capa DAO
    /// </summary>
    public class DAOException : Exception
    {
       
        public DAOException(string pDescription, Exception pException): base(pDescription, pException)
        {

        }

        public DAOException(string pDescription):base(pDescription)
        {
           
        }
    }
}

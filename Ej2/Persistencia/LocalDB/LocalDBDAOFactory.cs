using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej2.Persistencia.LocalDB
{
    public class LocalDBDAOFactory : DAOFactory
    {
        private string STRING_CONEXION = @"Data Source=(localdb)\v11.0;
                                        Initial Catalog = PruebaDB;
                                        Integrated Security = true;";
        
        private SqlConnection iConexion = null;
        private SqlTransaction iTransaction = null;

        public override ILibroDAO LibroDAO
        {
             get { return new LocalDBLibroDAO(iConexion); }
        }

        public override void IniciarConexion()
        {
            this.iConexion = new SqlConnection(STRING_CONEXION);   
        }

        public override void FinalizarConexion()
        {
            if(this.iConexion != null)
            {
                this.iConexion.Close();
            }
        }

        public override void IniciarTransaccion()
        {
            if(this.iConexion == null)
            {
                throw new DAOException("No se puede iniciar una transacción sin una conexión abierta.");
            }
           
            this.iTransaction = this.iConexion.BeginTransaction();
        }

        public override void Commit()
        {
            if (this.iTransaction != null)
            {
                this.iTransaction.Commit();
            }
        }

        public override void RollBack()
        {
            if (this.iTransaction != null)
            {
                this.iTransaction.Rollback();
            }
        }
    }
}

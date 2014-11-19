using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ej2.DTO;
using Ej2.Persistencia.LocalDB;

namespace Ej2.Tests
{
    [TestClass]
    public class LocalDBLibroDAOTests
    {
        [TestMethod]
        public void Insertar_Test()
        {
            string STRING_CONEXION = @"Data Source=(localdb)\v11.0;
                                        Initial Catalog = PruebaDB;
                                        Integrated Security = true;";

            SqlConnection mConexion = new SqlConnection(STRING_CONEXION);

            mConexion.Open();

            LocalDBLibroDAO mDAO = new LocalDBLibroDAO(mConexion);

            LibroDTO mDTO = new LibroDTO{Id = 5,
                                         Autor = "Félix Luna",
                                         Titulo = "Soy Roca",
                                         ISBN = "1234-9878"};

            mDAO.Insertar(mDTO);
            
            mConexion.Close();

            Assert.IsTrue(true);


        }
    }
}

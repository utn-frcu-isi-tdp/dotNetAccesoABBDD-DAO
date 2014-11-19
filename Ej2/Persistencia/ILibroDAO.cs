using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ej2.DTO;

namespace Ej2.Persistencia
{
    public interface ILibroDAO
    {
        void Insertar(LibroDTO pLibroDTO);

        IList<LibroDTO> Obtener();

        void Actualizar(LibroDTO pLibroDTO);

        void Borrar(LibroDTO pLibroDTO);
    }

}

using EMPLOYEEMAINTENANCE_API.DTO;
using System.Collections.Generic;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public interface ITrabajadorCon
    {
        bool Actualizar(TrabajadorActualizarDTO model, int id);
        bool Añadir(TrabajadorAgregarDTO model);
        bool Borrar(int? id);
        TrabajadorActualizarDTO BuscarPorID(int id);
        IEnumerable<TrabajadorActualizarDTO> Lists();
    }
}
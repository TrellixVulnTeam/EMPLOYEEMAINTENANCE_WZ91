using EMPLOYEEMAINTENANCE_API.DTO;
using System.Collections.Generic;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public interface IEdificiosCon
    {
        bool Actualizar(EdificiosActualizarDTO model, int id);
        bool Añadir(EdificiosAgregarDTO model);
        bool Borrar(int? id);
        EdificiosActualizarDTO BuscarPorID(int id);
        IEnumerable<EdificiosActualizarDTO> Lists();
    }
}
using EMPLOYEEMAINTENANCE_API.DTO;
using System.Collections.Generic;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public interface IAsignacionesCon
    {
        bool Actualizar(AsignacionesaActualizarDTO model, int id);
        bool Añadir(AsignacionesaAgregarDTO model);
        bool Borrar(int? id);
        AsignacionesaActualizarDTO BuscarPorID(int id);
        IEnumerable<AsignacionesaActualizarDTO> Lists();
    }
}
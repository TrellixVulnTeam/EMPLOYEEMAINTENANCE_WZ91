using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.DTO
{
    public class EdificiosActualizarDTO
    {
        [Required]
        public int EdificiosId { get; set; }

        [Required]
        [StringLength(4)]
        public string EdificioNum { get; set; }

        [Required]
        [StringLength(40)]
        public string EdificioDireccion { get; set; }


        [Required]
        [StringLength(12)]
        public string TipoEdif { get; set; }

        [Required]
        [StringLength(1)]

        public string NivelCal { get; set; }

        [Required]
        [StringLength(1)]
        public string Categor { get; set; }

    }
}

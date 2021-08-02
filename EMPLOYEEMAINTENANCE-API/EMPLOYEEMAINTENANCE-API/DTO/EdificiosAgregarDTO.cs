using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.DTO
{
    public class EdificiosAgregarDTO
    {

      

        [Required]
        [StringLength(4)]
        public string EdificioNum { get; set; }

        [Required]
        [StringLength(10)]
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

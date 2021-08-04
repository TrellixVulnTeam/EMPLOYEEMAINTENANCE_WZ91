using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.DTO
{
    public class AsignacionesaAgregarDTO
    {

        [Required]
        [StringLength(3)]
        public string AsigNum { get; set; }
        [Required]
        [StringLength(20)]
        [DataType(DataType.Date)]
        public string AsigFechIni { get; set; }
        [Required]
        [StringLength(3)]
        public string AsigNumDias { get; set; }
        [Required]

        public int EdificioNum_fk { get; set; }
        [Required]
        public int TrabajadorNum_fk { get; set; }

    }
}

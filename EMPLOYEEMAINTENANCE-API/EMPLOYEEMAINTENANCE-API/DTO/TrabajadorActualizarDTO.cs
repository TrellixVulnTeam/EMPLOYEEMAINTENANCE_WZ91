using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.DTO
{
    public class TrabajadorActualizarDTO
    {
        [Required]
        public int Trabajadorid { get; set; }

        [Required]
        [StringLength(5)]
        public string TrabajadorNum { get; set; }

        [Required]
        [StringLength(25)]
        public string TrabajadorNomb { get; set; }
        [Required]
        [StringLength(6)]
        public string TrabajadorTarif { get; set; }
        [Required]
        [StringLength(25)]
        public string Oficio { get; set; }
        [Required]
        [StringLength(5)]

        public string TrabajadorSuper { get; set; }



    }
}

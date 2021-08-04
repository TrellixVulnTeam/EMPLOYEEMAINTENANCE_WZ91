using AutoMapper;
using EMPLOYEEMAINTENANCE_API.DTO;
using EMPLOYEEMAINTENANCE_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.infrastructure.Automap
{
    public class automapperConfig : Profile
    {

        public automapperConfig()
        {
            AsignacionConId();
            AsignacionSinId();
            EdificioConId();
            EdificioSinId();
            trabajadoresConId();
            trabajadoresSinId();

        }


        private void AsignacionConId()
        {
            CreateMap<AsignacionesaActualizarDTO, Asignaciones>().ReverseMap();

        }

        private void AsignacionSinId()
        {
            CreateMap<Asignaciones,AsignacionesaAgregarDTO>().ReverseMap()
                .ForMember(a=>a.Asignacionid,opt => opt.Ignore());

        }
        private void EdificioConId()
        {
            CreateMap<EdificiosActualizarDTO, Edificios>().ReverseMap();

        }
        private void EdificioSinId()
        {
            CreateMap<Edificios, EdificiosAgregarDTO>().ReverseMap()
                 .ForMember(a => a.EdificiosId, opt => opt.Ignore());

        }
        private void trabajadoresConId()
        {
            CreateMap<TrabajadorActualizarDTO, Trabajador>().ReverseMap();

        }
        private void trabajadoresSinId()
        {
            CreateMap<Trabajador, TrabajadorAgregarDTO>().ReverseMap()
                 .ForMember(a => a.Trabajadorid, opt => opt.Ignore());

        }
    }


  

}

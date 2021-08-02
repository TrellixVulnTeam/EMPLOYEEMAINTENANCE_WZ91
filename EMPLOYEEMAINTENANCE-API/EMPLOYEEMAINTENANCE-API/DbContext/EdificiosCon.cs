using AutoMapper;
using EMPLOYEEMAINTENANCE_API.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class EdificiosCon: IEdificiosCon

    {
        IConfiguration _configuration;
        private readonly IMapper _mapper;

        public EdificiosCon(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        //string ConnectionString = "Server=.;Initial Catalog=EMPLOYEEMANAG;persist security info=True;Integrated Security=SSPI;";

        //Get list Edificios
        public IEnumerable<EdificiosActualizarDTO> Lists()
        {
            List<EdificiosActualizarDTO> listEdificios = new List<EdificiosActualizarDTO>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("ListadoEdificios", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Edificios edif = new Edificios
                    {
                        EdificiosId = Convert.ToInt32(dr["ID"]),
                        EdificioNum = dr["EdificioNum"].ToString(),
                        EdificioDireccion = dr["EdificioDireccion"].ToString(),
                        TipoEdif = dr["TipoEdif"].ToString(),
                        NivelCal = dr["NivelCal"].ToString(),
                        Categor = dr["Categor"].ToString()
                    };
                    var edficiosDTO = _mapper.Map<EdificiosActualizarDTO>(edif);
                    listEdificios.Add(edficiosDTO);
                }
                con.Close();
            }
            return listEdificios;
        }

        //Read for ID 
        public EdificiosActualizarDTO BuscarPorID(int id)
        {
            Edificios edif = new Edificios();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new("edificioPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    edif.EdificiosId = Convert.ToInt32(dr["ID"]);
                    edif.EdificioNum = dr["EdificioNum"].ToString();
                    edif.EdificioDireccion = dr["EdificioDireccion"].ToString();
                    edif.TipoEdif = dr["TipoEdif"].ToString();
                    edif.NivelCal = dr["NivelCal"].ToString();
                    edif.Categor = dr["Categor"].ToString();
                }
                con.Close();

            }
            var edficiosDTO = _mapper.Map<EdificiosActualizarDTO>(edif);

            return edficiosDTO;
        }
        //Create Edificios
        public bool Añadir(EdificiosAgregarDTO model)
        {
            bool res = false;
            var edficios = _mapper.Map<Edificios>(model);

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {

                SqlCommand cmd = new SqlCommand("insertarEdificio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EdificioNum", edficios.EdificioNum);
                cmd.Parameters.AddWithValue("@EdificioDireccion", edficios.EdificioDireccion);
                cmd.Parameters.AddWithValue("@TipoEdif", edficios.TipoEdif);
                cmd.Parameters.AddWithValue("@NivelCal", edficios.NivelCal);
                cmd.Parameters.AddWithValue("@Categor", edficios.Categor);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                con.Close();
            }
            return res;

        }

        //Remove Edificios
        public bool Borrar(int? id)
        {
            bool res = false;

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {

                SqlCommand cmd = new SqlCommand("borrarEdificio", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                con.Close();
            }
            return res;

        }

        //Update Edificios
        public bool Actualizar(EdificiosActualizarDTO model, int id)
        {
            bool res = false;
            var edficios = _mapper.Map<Edificios>(model);

            edficios.EdificiosId = id;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {

                SqlCommand cmd = new SqlCommand("actualizarEdificio", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", edficios.EdificiosId);
                cmd.Parameters.AddWithValue("@EdificioNum", edficios.EdificioNum);
                cmd.Parameters.AddWithValue("@EdificioDireccion", edficios.EdificioDireccion);
                cmd.Parameters.AddWithValue("@TipoEdif", edficios.TipoEdif);
                cmd.Parameters.AddWithValue("@NivelCal", edficios.NivelCal);
                cmd.Parameters.AddWithValue("@Categor", edficios.Categor);

                con.Open();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                con.Close();
            }
            return res;


        }
    }
}

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
    public class TrabajadorCon : ITrabajadorCon
    {
        IConfiguration _configuration;
        private readonly IMapper _mapper;

        public TrabajadorCon(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

      //  string ConnectionString = "Server=.;Initial Catalog=EMPLOYEEMANAG;persist security info=True;Integrated Security=SSPI;";

        public IEnumerable<TrabajadorActualizarDTO> Lists()
        {
            List<TrabajadorActualizarDTO> listTrabajadores = new List<TrabajadorActualizarDTO>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("ListadoTrabajador", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Trabajador trb = new Trabajador
                    {
                        TrabajadorNum = Convert.ToInt32(dr["TrabajadorNum"]),
                        TrabajadorNomb = dr["TrabajadorNomb"].ToString(),
                        TrabajadorTarif = dr["TrabajadorTarif"].ToString(),
                        Oficio = dr["Oficio"].ToString(),
                        TrabajadorSuper = dr["TrabajadorSuper"].ToString()
                    };
                    var trabajadorDTO = _mapper.Map<TrabajadorActualizarDTO>(trb);
                    listTrabajadores.Add(trabajadorDTO);

                }
                con.Close();

            }

            return listTrabajadores;

        }

        public IEnumerable<TrabajadorActualizarDTO> ListsClean()
        {
            List<TrabajadorActualizarDTO> listTrabajadores = new List<TrabajadorActualizarDTO>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("ListadoTrabajadoresClean", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Trabajador trb = new Trabajador
                    {
                        TrabajadorNum = Convert.ToInt32(dr["TrabajadorNum"]),
                        TrabajadorNomb = dr["TrabajadorNomb"].ToString(),
                        TrabajadorTarif = dr["TrabajadorTarif"].ToString(),
                        Oficio = dr["Oficio"].ToString(),
                        TrabajadorSuper = dr["Supervisor"].ToString()
                    };
                    var trabajadorDTO = _mapper.Map<TrabajadorActualizarDTO>(trb);
                    listTrabajadores.Add(trabajadorDTO);

                }
                con.Close();

            }

            return listTrabajadores;

        }

        public TrabajadorActualizarDTO BuscarPorID(int id)
        {
            Trabajador trb = new Trabajador();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
            {
                SqlCommand cmd = new SqlCommand("trabajadorPorId", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    trb.TrabajadorNum = Convert.ToInt32(dr["TrabajadorNum"]);
                    trb.TrabajadorNomb = dr["TrabajadorNomb"].ToString();
                    trb.TrabajadorTarif = dr["TrabajadorTarif"].ToString();
                    trb.Oficio = dr["Oficio"].ToString();
                    trb.TrabajadorSuper = dr["TrabajadorSuper"].ToString();

                }
                con.Close();

            }
            var trabajadorDTO = _mapper.Map<TrabajadorActualizarDTO>(trb);

            return trabajadorDTO;

        }

        public bool Añadir(TrabajadorAgregarDTO model)
        {
            bool res = false;
            var TRABAJADOR = _mapper.Map<Trabajador>(model);

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("insertarTrabajador", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrabajadorNomb", TRABAJADOR.TrabajadorNomb);
                cmd.Parameters.AddWithValue("@TrabajadorSuper", TRABAJADOR.TrabajadorSuper);
                cmd.Parameters.AddWithValue("@TrabajadorTarif", TRABAJADOR.TrabajadorTarif);
                cmd.Parameters.AddWithValue("@Oficio", TRABAJADOR.Oficio);

                con.Open();
                //var test = cmd.ExecuteScalar();
                if (cmd.ExecuteNonQuery() > 0)
                {
                    res = true;
                }
                con.Close();
            }
            return res;


        }

        public bool Borrar(int? id)
        {
            bool res = false;

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("borrarTrabajador", con);
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


        public bool Actualizar(TrabajadorActualizarDTO model, int id)
        {
            bool res = false;
            var trabajador = _mapper.Map<Trabajador>(model);
            trabajador.TrabajadorNum = id;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

            {
                SqlCommand cmd = new SqlCommand("actualizarTrabajador", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TrabajadorNomb", trabajador.TrabajadorNomb);
                cmd.Parameters.AddWithValue("@TrabajadorNum", trabajador.TrabajadorNum);
                cmd.Parameters.AddWithValue("@TrabajadorSuper", trabajador.TrabajadorSuper);
                cmd.Parameters.AddWithValue("@TrabajadorTarif", trabajador.TrabajadorTarif);
                cmd.Parameters.AddWithValue("@Oficio", trabajador.Oficio);

                con.Open();
                //var test = cmd.ExecuteScalar();

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
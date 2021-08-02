using AutoMapper;
using EMPLOYEEMAINTENANCE_API.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EMPLOYEEMAINTENANCE_API.Models
{
    public class AsignacionesCon: IAsignacionesCon
    {
        IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AsignacionesCon(IConfiguration  configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        //string ConnectionString = "Server=DTIC-16\\SQLSERVERX;Initial Catalog=EMPLOYEEMANAG;persist security info=True;Integrated Security=SSPI;";

        //Get list Asignaciones
        public IEnumerable<AsignacionesaActualizarDTO> Lists()
            {
                List<AsignacionesaActualizarDTO> listAsignaciones = new List<AsignacionesaActualizarDTO>();

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
                {
                    SqlCommand cmd = new SqlCommand("ListadoAsignaciones", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                    Asignaciones asig = new Asignaciones
                        {
                            Asignacionid = Convert.ToInt32(dr["ID"]),
                            AsigNum = dr["AsigNum"].ToString(),
                            AsigFechIni = (DateTime.Parse(dr["AsigFechIni"].ToString()).Date).ToString(),
                            AsigNumDias = dr["AsigNumDias"].ToString(), 
                            EdificioNum_fk = Convert.ToInt32(dr["EdificioNum_fk"]),
                            TrabajadorNum_fk = Convert.ToInt32(dr["TrabajadorNum_fk"]),
                        };

                    var asignacionesDTO = _mapper.Map<AsignacionesaActualizarDTO>(asig);
                        listAsignaciones.Add(asignacionesDTO);
                    }
                    con.Close();
                }
                return listAsignaciones;
            }

            //Read for ID 
            public AsignacionesaActualizarDTO BuscarPorID(int id)
            {

            Asignaciones asg = new Asignaciones();
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
                {
                    SqlCommand cmd = new("asignacionPorId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        asg.Asignacionid = Convert.ToInt32(dr["ID"]);
                        asg.AsigNum = dr["AsigNum"].ToString();
                        asg.AsigFechIni = (DateTime.Parse(dr["AsigFechIni"].ToString()).Date).ToString();
                        asg.AsigNumDias = dr["AsigNumDias"].ToString();
                        asg.EdificioNum_fk = Convert.ToInt32(dr["EdificioNum_fk"]);
                        asg.TrabajadorNum_fk = Convert.ToInt32(dr["TrabajadorNum_fk"]);

                    };
                    con.Close();
                }
                     var res = _mapper.Map<AsignacionesaActualizarDTO>(asg);
                return res;
            }
            //Create Asignaciones
            public bool Añadir(AsignacionesaAgregarDTO model)
            {
            bool res = false;
                var asg = _mapper.Map<Asignaciones>(model);
          

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

                {
                    SqlCommand cmd = new SqlCommand("insertarAsignacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID", asg.Asignacionid);
                    cmd.Parameters.AddWithValue("@AsigNum", asg.AsigNum);
                    cmd.Parameters.AddWithValue("@AsigFechIni", asg.AsigFechIni); 
                    cmd.Parameters.AddWithValue("@AsigNumDias", asg.AsigNumDias);
                    cmd.Parameters.AddWithValue("@EdificioNum_fk", asg.EdificioNum_fk);
                    cmd.Parameters.AddWithValue("@TrabajadorNum_fk", asg.TrabajadorNum_fk);

                    con.Open();
                   if (cmd.ExecuteNonQuery() > 0)
                    {
                    res = true;
                    } 
                    con.Close();
                }
            return res;
            }

            //Remove Asignaciones
            public bool Borrar(int? id)
        {
                bool res = false;

                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))
                {
                    SqlCommand cmd = new SqlCommand("borrarAsignacion", con);
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

        //Update Asignaciones
        public bool Actualizar(AsignacionesaActualizarDTO asg, int id)
        {
                 bool res = false;
                 var model = _mapper.Map<Asignaciones>(asg);

                 model.Asignacionid = id;
                using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("prjectdn")))

                {
                    SqlCommand cmd = new SqlCommand("actualizarAsignacion", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ID", model.Asignacionid);
                    cmd.Parameters.AddWithValue("@AsigNum", model.AsigNum);
                    cmd.Parameters.AddWithValue("@AsigFechIni", model.AsigFechIni);
                    cmd.Parameters.AddWithValue("@AsigNumDias", model.AsigNumDias);
                    cmd.Parameters.AddWithValue("@EdificioNum_fk", model.EdificioNum_fk);
                    cmd.Parameters.AddWithValue("@TrabajadorNum_fk", model.TrabajadorNum_fk);

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


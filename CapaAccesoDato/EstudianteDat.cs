using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDato
{
    public class EstudianteDat
    {
        private static readonly EstudianteDat estudianteDat = new EstudianteDat();
        public static EstudianteDat Instancia
        {
            get
            {
                return EstudianteDat.estudianteDat;
            }
        }

        public List<Estudiante> ListaEstudiantes()
        {
            List<Estudiante> listado = new List<Estudiante>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("listaEstudiantes", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Estudiante estudiante = new Estudiante
                    {
                        idEstudiante = Convert.ToInt32(dr["idEstudiante"]),
                        codigo = Convert.ToString(dr["codigo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]),
                        apellidoMaterno = Convert.ToString(dr["apellidoMaterno"]),
                        status = Convert.ToInt32(dr["status"]),
                    };
                    Carrera carrera = new Carrera
                    {
                        idCarrera = Convert.ToInt32(dr["idCarrera"]),
                        nombre = Convert.ToString(dr["nombreCarrera"]),
                        status = Convert.ToInt32(dr["statusCarrera"]),
                    };

                    estudiante.carrera = carrera;

                    listado.Add(estudiante);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listado;
        }

        public Estudiante BuscarEstudiante(int idEstudiante)
        {
            Estudiante estudiante = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdEstudiante", idEstudiante);
                cn.Open(); 

                 SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    estudiante = new Estudiante
                    {
                        idEstudiante = Convert.ToInt32(dr["idEstudiante"]),
                        codigo = Convert.ToString(dr["codigo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]),
                        apellidoMaterno = Convert.ToString(dr["apellidoMaterno"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return estudiante;
        }
        public Estudiante BuscarEstudianteCarrera(int idEstudiante)
        {
            Estudiante estudiante = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarEstudianteCarrera", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdEstudiante", idEstudiante);
                cn.Open(); 

                 SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    estudiante = new Estudiante
                    {
                        idEstudiante = Convert.ToInt32(dr["idEstudiante"]),
                        codigo = Convert.ToString(dr["codigo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        apellidoPaterno = Convert.ToString(dr["apellidoPaterno"]),
                        apellidoMaterno = Convert.ToString(dr["apellidoMaterno"]),
                        status = Convert.ToInt32(dr["status"]),
                        idCarrera = Convert.ToInt32(dr["idCarrera"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return estudiante;
        }
    }
}

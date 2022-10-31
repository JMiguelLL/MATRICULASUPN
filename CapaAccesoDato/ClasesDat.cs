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
    public class ClasesDat
    {
        private static readonly ClasesDat clasesDat = new ClasesDat();
        public static ClasesDat Instancia
        {
            get
            {
                return ClasesDat.clasesDat;
            }
        }

        public List<Clase> ListaClasesCurso(int idCurso)
        {
            List<Clase> listado = new List<Clase>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("listaClasesCurso", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdCurso", idCurso);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Clase clase = new Clase
                    {
                        idClase = Convert.ToInt32(dr["idClase"]),
                        codigo = Convert.ToString(dr["codigo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        horaInicio = Convert.ToDateTime(dr["horaInicio"]),
                        horaFin = Convert.ToDateTime(dr["horaFin"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                    Aula aula = new Aula
                    {
                        idAula = Convert.ToInt32(dr["idAula"]),
                        codigo = Convert.ToString(dr["codigoAula"]),
                        status = Convert.ToInt32(dr["statusAula"]),
                    };

                    clase.aula = aula;

                    listado.Add(clase);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listado;
        }

        public Clase BuscarClase(int idClase)
        {
            Clase clase = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarClase", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdClase", idClase);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    clase = new Clase
                    {
                        idClase = Convert.ToInt32(dr["idClase"]),
                        codigo = Convert.ToString(dr["codigo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        horaInicio = Convert.ToDateTime(dr["horaInicio"]),
                        horaFin = Convert.ToDateTime(dr["horaFin"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return clase;
        }
        

        public List<Clase> CursosMatriculados(int idMatricula)
        {
            List<Clase> listado = new List<Clase>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("cursosMatriculados", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdMatricula", idMatricula);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Clase clase = new Clase
                    {
                        idClase = Convert.ToInt32(dr["idClase"]),
                        codigo = Convert.ToString(dr["codigo"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        horaInicio = Convert.ToDateTime(dr["horaInicio"]),
                        horaFin = Convert.ToDateTime(dr["horaFin"]),
                    };

                    Aula aula = new Aula
                    {
                        codigo = Convert.ToString(dr["codigoAula"]),
                    };
                    Curso curso = new Curso
                    {
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                        nombre = Convert.ToString(dr["nombreCurso"]),
                        creditos = Convert.ToInt32(dr["creditos"]),
                    };

                    clase.aula = aula;
                    clase.curso = curso;

                    listado.Add(clase);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listado;
        }
    }
}

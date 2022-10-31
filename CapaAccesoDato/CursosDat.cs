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
    public class CursosDat
    { 
        private static readonly CursosDat cursosDat = new CursosDat();
        public static CursosDat Instancia
        {
            get
            {
                return CursosDat.cursosDat;
            }
        }

        public List<Curso> ListaCursosCarrera(int idCarrera)
        {
            List<Curso> listado = new List<Curso>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("listCursosCarrera", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdCarrera", idCarrera);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Curso curso = new Curso
                    {
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        creditos = Convert.ToInt32(dr["creditos"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                    listado.Add(curso);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listado;
        }

        public List<Curso> ListaCursosCarreraPeriodo(int idCarrera, int idPeriodo)
        {
            List<Curso> listado = new List<Curso>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("listCursosCarreraPeriodo", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdCarrera", idCarrera);
                cmd.Parameters.AddWithValue("@paramIdPeriodo", idPeriodo);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Curso curso = new Curso
                    {
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        creditos = Convert.ToInt32(dr["creditos"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                    listado.Add(curso);
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return listado;
        }

        public Curso BuscarCurso(int idCurso)
        {
            Curso curso = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarCurso", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdCurso", idCurso);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    curso = new Curso
                    {
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                        nombre = Convert.ToString(dr["nombre"]),
                        creditos = Convert.ToInt32(dr["creditos"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return curso;
        }
        public Curso BuscarCursoMatricula(int idMatricula, int idCurso)
        {
            Curso curso = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarCursoMatricula", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdMatricula", idMatricula);
                cmd.Parameters.AddWithValue("@paramIdCurso", idCurso);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    curso = new Curso
                    {
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return curso;
        } 
        public Curso BuscarCursoAnterior( int idCurso, int idEstudiante)
        {
            Curso curso = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarCursoAnterior", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdCurso", idCurso);
                cmd.Parameters.AddWithValue("@paramIdEstudiante", idEstudiante);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    curso = new Curso
                    {
                        idCurso = Convert.ToInt32(dr["idCurso"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return curso;
        }
    }
}

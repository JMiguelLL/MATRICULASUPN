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
    public class MatriculaDetalleDat
    {
        private static readonly MatriculaDetalleDat matriculaDetalleDat = new MatriculaDetalleDat();
        public static MatriculaDetalleDat Instancia
        {
            get
            {
                return matriculaDetalleDat;
            }
        }

        public MatriculaDetalle NuevaMatriculaDetalle(MatriculaDetalle matriculaDetalle)
        {
            MatriculaDetalle newMatriculaDetalle = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("nuevaMatriculaDetalle", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdClase", matriculaDetalle.idClase);
                cmd.Parameters.AddWithValue("@paramIdMatricula", matriculaDetalle.idMatricula);
                cmd.Parameters.AddWithValue("@paramStatus", matriculaDetalle.status);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    newMatriculaDetalle = new MatriculaDetalle
                    {
                        idMatriculaDetalle = Convert.ToInt32(dr["idMatriculaDetalle"]),
                    };
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return newMatriculaDetalle;
        }

        public MatriculaDetalle BuscarDetalleCurso(int idMatricula, int idCurso)
        {
            MatriculaDetalle matriculaDetalle = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdEstudiante", idMatricula);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    matriculaDetalle = new MatriculaDetalle
                    {
                        idMatriculaDetalle = Convert.ToInt32(dr["idMatriculaDetalle"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return matriculaDetalle;
        }
        public MatriculaDetalle BuscarDetalleClase(int idMatricula, int idClase)
        {
            MatriculaDetalle matriculaDetalle = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarDetalleClase", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdMatricula", idMatricula);
                cmd.Parameters.AddWithValue("@paramIdClase", idClase);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    matriculaDetalle = new MatriculaDetalle
                    {
                        idMatriculaDetalle = Convert.ToInt32(dr["idMatriculaDetalle"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return matriculaDetalle;
        }

        public void EliminarCursoMatriculado(int idMatriculaDetalle)
        {
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("eliminarCursoMatriculado", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdMatriculaDetalle", idMatriculaDetalle);
                cn.Open();

                cmd.ExecuteReader();

                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

    }
}

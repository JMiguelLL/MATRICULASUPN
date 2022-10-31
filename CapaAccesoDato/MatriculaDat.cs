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
    public class MatriculaDat
    {
        private static readonly MatriculaDat matriculaDat = new MatriculaDat();
        public static MatriculaDat Instancia
        {
            get
            {
                return MatriculaDat.matriculaDat;
            }
        }
        

        public Matricula BuscarMatriculaEstudiante(int idEstudiante, int idPeriodo)
        {
            Matricula matricula = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarMatriculaEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdEstudiante", idEstudiante);
                cmd.Parameters.AddWithValue("@paramIdPeriodo", idPeriodo);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    matricula = new Matricula
                    {
                        idMatricula = Convert.ToInt32(dr["idMatricula"]),
                        fechaMatricula = Convert.ToDateTime(dr["fechaMatricula"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return matricula;
        }

        public Matricula NuevaMatricula(Matricula matricula)
        {
            Matricula newMatricula = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("nuevaMatricula", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramFechaMatricula", matricula.fechaMatricula);
                cmd.Parameters.AddWithValue("@paramIdEstudiante", matricula.idEstudiante);
                cmd.Parameters.AddWithValue("@paramIdPeriodo", matricula.idPeriodo);
                cmd.Parameters.AddWithValue("@paramStatus", matricula.status);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    newMatricula = new Matricula
                    {
                        idMatricula = Convert.ToInt32(dr["idMatricula"]),
                    };
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return newMatricula;
        }


        public Matricula BuscarMatriculaActivaEstudiante(int idEstudiante)
        {
            Matricula matricula = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("buscarMatriculaActivaEstudiante", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramIdEstudiante", idEstudiante);
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    matricula = new Matricula
                    {
                        idMatricula = Convert.ToInt32(dr["idMatricula"]),
                        fechaMatricula = Convert.ToDateTime(dr["fechaMatricula"]),
                        status = Convert.ToInt32(dr["status"]),
                    };

                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return matricula;
        }
    }
}

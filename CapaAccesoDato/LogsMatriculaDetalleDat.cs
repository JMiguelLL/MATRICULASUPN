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
    public class LogsMatriculaDetalleDat
    {

        private static readonly LogsMatriculaDetalleDat logsMatriculaDetalleDat = new LogsMatriculaDetalleDat();
        public static LogsMatriculaDetalleDat Instancia
        {
            get
            {
                return LogsMatriculaDetalleDat.logsMatriculaDetalleDat;
            }
        }

        public Boolean NuevoLogMatriculaDetalle(LogsMatriculaDetalle logMatriculaDetalle)
        {
            Boolean created = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conect();
                SqlCommand cmd = new SqlCommand("nuevoLogMatriculaDetalle", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@paramFechaRegistro", logMatriculaDetalle.fechaRegistro);
                cmd.Parameters.AddWithValue("@paramAccion", logMatriculaDetalle.accion);
                cmd.Parameters.AddWithValue("@paramIdMatriculaDetalle", logMatriculaDetalle.idMatriculaDetalle);
                cmd.Parameters.AddWithValue("@paramIdUsuario", logMatriculaDetalle.idUsuario);

                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    created = true;
                }
                cn.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            return created;
        }
    }
}
